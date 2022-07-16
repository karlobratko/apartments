using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.WebUI.Models;
using Apartments.WebUI.ViewModels;

namespace Apartments.WebUI.Controllers {
  public class ApartmentController : BaseController {
    private readonly IApartmentDomainModelManager _apartmentManager;
    private readonly ICityDomainModelManager _cityManager;
    private readonly IOwnerDomainModelManager _ownerManager;
    private readonly IStatusDomainModelManager _statusManager;
    private readonly IPictureDomainModelManager _pictureManager;
    private readonly ITagDomainModelManager _tagManager;
    private readonly IReservationDomainModelManager _reservationManager;
    private readonly IReviewDomainModelManager _reviewManager;
    private readonly IUserDomainModelManager _userManager;

    public ApartmentController(IApartmentDomainModelManager apartmentManager,
                               ICityDomainModelManager cityManager,
                               IOwnerDomainModelManager ownerManager,
                               IStatusDomainModelManager statusManager,
                               IPictureDomainModelManager pictureManager,
                               ITagDomainModelManager tagManager,
                               IReservationDomainModelManager reservationManager,
                               IReviewDomainModelManager reviewManager,
                               IUserDomainModelManager userManager) {
      _apartmentManager = apartmentManager;
      _cityManager = cityManager;
      _ownerManager = ownerManager;
      _statusManager = statusManager;
      _pictureManager = pictureManager;
      _tagManager = tagManager;
      _reservationManager = reservationManager;
      _reviewManager = reviewManager;
      _userManager = userManager;
    }

    [HttpGet]
    [LocalizedRoute(template: "~/search")]
    public ViewResult Search(ApartmentSearchSettings searchSettings)
      => View(viewName: nameof(ApartmentController.Search),
              model: new ApartmentSearchViewModel {
                SearchSettings = searchSettings,
                Cities = _cityManager.GetAllIfAvailable()
              });

    [HttpGet]
    [LocalizedRoute(template: "~/apartment/{id:int}")]
    public ActionResult Details(Int32 id) {
      ApartmentDomainModel model = _apartmentManager.GetByIdIfAvailable(id);
      if (model is null)
        return new HttpStatusCodeResult(404);

      String culture = RouteData.Values["culture"].ToString();

      IEnumerable<PictureDomainModel> pictures = _pictureManager.GetByApartment(model);
      StatusDomainModel status = _statusManager.GetByIdIfAvailable(model.StatusFK);
      return View(viewName: nameof(ApartmentController.Details),
                  model: new ApartmentDetailsViewModel {
                    Id = model.Id,
                    Name = culture == "en" ? model.NameEng : model.Name,
                    Price = model.Price,
                    Address = model.Address,
                    BeachDistance = model.BeachDistance,
                    MaxAdults = model.MaxAdults,
                    TotalRooms = model.TotalRooms,
                    MaxChildren = model.MaxChildren,
                    City = _cityManager.GetById(model.CityFK).Name,
                    Owner = _ownerManager.GetByIdIfAvailable(model.OwnerFK).Name,
                    Status = culture == "en" ? status.NameEng : status.Name,
                    RepresentativePicture = pictures.FirstOrDefault(predicate: picture => picture.IsRepresentative),
                    Pictures = pictures.OrderBy(keySelector: picture => picture.IsRepresentative),
                    Tags = _tagManager.GetByApartment(model)
                  });
    }

    [HttpPost]
    [Route(template: "~/apartment/reservation")]
    public JsonResult Reservation(ApartmentReservationModel model) {
      if (!ModelState.IsValid) {
        return Json(behavior: JsonRequestBehavior.DenyGet,
                    data: new {
                      Message = Resources.Global.Apartments.ResourceManager.GetString(name: "reservation-failed"),
                      Success = false
                    });
      }

      ReservationDomainModel reservation = _reservationManager.Add(new ReservationDomainModel {
        ApartmentFK = model.ApartmentFK,
        Details = $"{model.DateFrom} - {model.DateTo}",
        UserFName = model.FName,
        UserLName = model.LName,
        UserEmail = model.Email,
        UserAddress = model.Address,
        UserPhoneNumber = model.PhoneNumber
      });

      return reservation is null
        ? Json(behavior: JsonRequestBehavior.DenyGet,
               data: new {
                 Message = Resources.Global.Apartments.ResourceManager.GetString(name: "reservation-failed"),
                 Success = false
               })
        : Json(behavior: JsonRequestBehavior.DenyGet,
               data: new {
                 Message = Resources.Global.Apartments.ResourceManager.GetString(name: "reservation-success"),
                 Success = true
               });
    }

    [HttpPost]
    [Route(template: "~/apartment/review")]
    public JsonResult Review(ApartmentReviewModel model) {
      if (!ModelState.IsValid) {
        return Json(behavior: JsonRequestBehavior.DenyGet,
                    data: new {
                      Message = Resources.Global.Apartments.ResourceManager.GetString(name: "review-failed"),
                      Success = false
                    });
      }

      ReviewDomainModel review = _reviewManager.Add(new ReviewDomainModel {
        UserFK = model.UserFK,
        ApartmentFK = model.ApartmentFK,
        Stars = model.Stars,
        Details = model.Details
      });

      return review is null
        ? Json(behavior: JsonRequestBehavior.DenyGet,
               data: new {
                 Message = Resources.Global.Apartments.ResourceManager.GetString(name: "review-failed"),
                 Success = false
               })
        : Json(behavior: JsonRequestBehavior.DenyGet,
               data: new {
                 Message = Resources.Global.Apartments.ResourceManager.GetString(name: "review-success"),
                 Success = true
               });
    }

    [HttpGet]
    [Route(template: "~/apartment/getpicturejson/{id:int:min(1)}")]
    public JsonResult GetPictureJson(Int32 id)
      => Json(data: _pictureManager.GetByIdIfAvailable(id), behavior: JsonRequestBehavior.AllowGet);

    [HttpGet]
    [Route(template: "~/apartment/getfilteredjson")]
    public JsonResult GetFilteredJson(ApartmentSearchSettings searchSettings)
      => Json(data: GetFilteredData(searchSettings), behavior: JsonRequestBehavior.AllowGet);

    [HttpGet]
    public PartialViewResult GetFiltered(ApartmentSearchSettings searchSettings)
      => PartialView(viewName: $"_GetApartments", model: GetFilteredData(searchSettings));

    [HttpGet]
    public JsonResult GetReviewsJson(Int32 apartmentFK)
      => Json(data: GetReviewsData(apartmentFK), behavior: JsonRequestBehavior.AllowGet);

    [HttpGet]
    public PartialViewResult GetReviews(Int32 apartmentFK)
      => PartialView(viewName: $"_GetApartmentReviews", model: GetReviewsData(apartmentFK).Take(count: 3));

    private IEnumerable<ReviewCardViewModel> GetReviewsData(Int32 apartmentFK)
      => from review in _reviewManager.GetByApartment(new ApartmentDomainModel { Id = apartmentFK })
         let user = _userManager.GetById(id: review.UserFK)
         select new ReviewCardViewModel {
           UserFName = user.FName,
           UserLName = user.LName,
           Stars = review.Stars,
           Details = review.Details
         };

    private Byte[] ReducePictureQuality(Byte[] inputBytes) {
      if (inputBytes == null) return null;
      Int32 jpegQuality = 20;
      Image image;
      using (var inputStream = new MemoryStream(inputBytes)) {
        image = Image.FromStream(inputStream);
        ImageCodecInfo jpegEncoder = ImageCodecInfo.GetImageDecoders()
          .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
        var encoderParameters = new EncoderParameters(1);
        encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, jpegQuality);
        Byte[] outputBytes;
        using (var outputStream = new MemoryStream()) {
          image.Save(outputStream, jpegEncoder, encoderParameters);
          outputBytes = outputStream.ToArray();
          return outputBytes;
        }
      }
    }

    private IEnumerable<ApartmentCardViewModel> GetFilteredData(ApartmentSearchSettings searchSettings) {
      String culture = RouteData.Values["culture"].ToString();

      IEnumerable<ApartmentCardViewModel> apartments =
        from apartment in _apartmentManager.GetAllIfAvailable()
        let city = _cityManager.GetByIdIfAvailable(apartment.CityFK)
        let owner = _ownerManager.GetByIdIfAvailable(apartment.OwnerFK)
        let status = _statusManager.GetByIdIfAvailable(apartment.StatusFK)
        let picture = _pictureManager.GetRepresentative(apartment)
        where searchSettings.TotalRooms is null || apartment.TotalRooms == searchSettings.TotalRooms
        where searchSettings.MaxAdults is null || apartment.MaxAdults == searchSettings.MaxAdults
        where searchSettings.MaxChildren is null || apartment.MaxChildren == searchSettings.MaxChildren
        where city.Name.ToLower().Contains(value: searchSettings.CityName?.ToLower() ?? "")
        select new ApartmentCardViewModel {
          Id = apartment.Id,
          Name = culture == "en" ? apartment.NameEng : apartment.Name,
          Address = apartment.Address,
          City = city.Name,
          Owner = owner.Name,
          Status = culture == "en" ? status.NameEng : status.Name,
          ImageData = ReducePictureQuality(picture?.Data),
          MimeType = picture?.MimeType,
          DetailsUrl = UrlHelper.GenerateUrl(routeName: null,
                                             actionName: "Details",
                                             controllerName: "Apartment",
                                             routeValues: new RouteValueDictionary {
                                               { "id", apartment.Id },
                                             },
                                             routeCollection: RouteTable.Routes,
                                             requestContext: Request.RequestContext,
                                             includeImplicitMvcValues: false)
        };

      apartments = apartments.SortBy(keySelector: model
                                       => typeof(ApartmentCardViewModel).GetProperty(name: String.IsNullOrEmpty(searchSettings.SortBy)
                                                                                       ? "Id"
                                                                                       : searchSettings.SortBy)
                                                                        .GetValue(model),
                                     sortDirection: searchSettings.SortDirection);

      return apartments;
    }
  }
}