using System;
using System.Collections.Generic;

namespace ObiletcomProject.Models
{
    public class JourneyIndexDetail
    {
        public JourneyIndexDetail()
        {
            List<OriginandDestinationDetail> originandDestinationDetails = null;
        }

        public List<OriginandDestinationDetail> originandDestinationDetails { get; set; }
        public string OriginLocation { get; set; }
        public int OriginLocationId { get; set; }
        public string DestinationLocation { get; set; }
        public int DestinationLocationId { get; set; }
        public DateTime Departure { get; set; }
    }
}