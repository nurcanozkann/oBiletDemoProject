using ObiletcomProject.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletcomProject.BusinessLayer.Abstract
{
    public interface IJourneyService
    {
        BusJourneyViewModel.BusJourney GetJourneyDetail(int frombuslocation, int tobuslocation, DateTime flatpickr);
    }
}
