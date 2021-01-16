using ObiletcomProject.BusinessLayer;
using ObiletcomProject.BusinessLayer.Concrete;
using ObiletcomProject.Entities.ViewModel;
using ObiletcomProject.Helper;
using ObiletcomProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ObiletcomProject.Controllers
{
    public class HomeController : Controller
    {
        private SessionManager sessionManager = new SessionManager();
        private BusLocationManager busLocationManager = new BusLocationManager();
        private JourneyManager journeyManager = new JourneyManager();

        [HttpGet]
        public ActionResult Index()
        {
            var getSessionInfo = sessionManager.CreateSession();
            CurrentSession.Set("sessionInfo", getSessionInfo.data.SessionId);
            CurrentSession.Set("deviceId", getSessionInfo.data.DeviceId);
            ViewBag.SessionInfo = CurrentSession.User;

            var busLocationInfo = busLocationManager.GetBusLocations();
            GetBusLocation(busLocationInfo);

            return View();
        }

        [HttpPost]
        public ActionResult Index(int frombuslocation, int tobuslocation, DateTime flatpickr)
        {
            List<OriginandDestinationDetail> originandDestinationDetails = new List<OriginandDestinationDetail>();
            var data = new OriginandDestinationDetail();
            var busJourneyDetail = journeyManager.GetJourneyDetail(frombuslocation, tobuslocation, flatpickr);
            foreach (var item in busJourneyDetail.data.OrderBy(x => x.journey.departure))
            {
                data = new OriginandDestinationDetail
                {
                    Origin = item.journey.origin,
                    Destination = item.journey.destination,
                    OriginLocation = item.OriginLocation,
                    DestinationLocation = item.DestinationLocation,
                    Departure = item.journey.departure.Value.ToShortTimeString(),
                    Price = item.journey.OriginalPrice.ToString(),
                    Arrical = item.journey.arrival.Value.ToShortTimeString(),
                    Currency = item.journey.currency,
                    JourneyId = item.id
                };

                originandDestinationDetails.Add(data);
            }
            TempData["OriginLocation"] = data.OriginLocation;
            TempData["OriginLocationId"] = frombuslocation;
            TempData["DestinationLocation"] = data.DestinationLocation;
            TempData["DestinationLocationId"] = tobuslocation;
            TempData["Departure"] = flatpickr.ToShortDateString();  /*item.journey.departure.Value.ToShortDateString();*/
            TempData["ListInfo"] = originandDestinationDetails;

            Session["originlocation"] = data.OriginLocation;
            Session["originlocationid"] = frombuslocation;
            Session["destinationlocation"] = data.DestinationLocation;
            Session["destinationlocationid"] = tobuslocation;
            Session["departure"] = flatpickr.ToString("MM.dd.yyyy");

            return RedirectToAction("Index", "Journey", new { originId = SeoContent.AdresDuzenle(frombuslocation), destinationId = SeoContent.AdresDuzenle(tobuslocation), departuredate = SeoContent.AdresDuzenle(flatpickr.ToShortDateString()) });
        }

        public void GetBusLocation(BusLocationViewModel busLocationInfo)
        {
            List<SelectListItem> frombusLocation = new List<SelectListItem>();
            foreach (var item in busLocationInfo.data)
            {
                frombusLocation.Add(new SelectListItem { Text = item.name, Value = item.id.ToString() });
            }
            ViewBag.FromBusLocation = frombusLocation;
            ViewBag.ToBusLocation = frombusLocation;
        }
    }
}