using ObiletcomProject.BusinessLayer.Concrete;
using ObiletcomProject.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ObiletcomProject.Controllers
{
    public class JourneyController : Controller
    {
        private JourneyManager journeyManager = new JourneyManager();

        [HttpGet]
        [Route("seferler/{originId}-{destinationId}/{departuredate}")]
        public ActionResult Index(int originId, int destinationId, DateTime? departuredate)
        {
            var detailInfo = new JourneyIndexDetail
            {
                originandDestinationDetails = TempData["ListInfo"] as List<OriginandDestinationDetail>,
                Departure = Convert.ToDateTime(TempData["Departure"].ToString()),
                DestinationLocation = TempData["DestinationLocation"].ToString(),
                DestinationLocationId = Convert.ToInt32(TempData["DestinationLocationId"]),
                OriginLocation = TempData["OriginLocation"].ToString(),
                OriginLocationId = Convert.ToInt32(TempData["OriginLocationId"]),
            };
            //var data = TempData["ListInfo"] as List<OriginandDestinationDetail>;
            return View(detailInfo);
        }

        [Route("seferlerdetay/{originId}-{destinationId}/{departuredate}/{journeyid}")]
        public ActionResult JourneyDetail(int originId, int destinationId, DateTime? departuredate, int journeyid)
        {
            return View();
        }
    }
}