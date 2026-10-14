using Microsoft.IdentityModel.Tokens;
using prakt6_Leshukov.Models;

namespace prakt6_Leshukov.Services
{
    public class EventService
    {
        private WebApiDatabaseContext _db = DBServices.Instance.Context;
        public List<Event> GetAll (string? location, bool? isActive)
        {
            List<Event> events = _db.Events.ToList();

            if (!string.IsNullOrWhiteSpace(location))
                events = events.Where(e => e.Location.Contains(location)).ToList();

            if (isActive != null)
                events = events.Where(e => e.IsActive == isActive.Value).ToList();

            return events;
        }
        public Event Get (int id)
        {
           
            var eventFind = _db.Events.FirstOrDefault(i => i.Id == id);
            if (eventFind == null) return null;
            return eventFind;
        }
        public bool Create(Event ev)
        {
            if (ev == null) return false;
            if (ev.Title.IsNullOrEmpty()) return false;
            if (ev.Location.IsNullOrEmpty()) return false;
            if (ev.EventDate == null) return false;
            if (ev.TicketPrice == null) return false;
            if (ev.IsActive == null) return false;
            ev.Id = 0;
            _db.Events.Add(ev);
            _db.SaveChanges( );
            return true;
        }
        public Event? Change(int id,Event ev)
        {
            var eventFind = _db.Events.FirstOrDefault(i => i.Id == id);
            if (eventFind == null) return null;
            if (ev == null) return null;
            eventFind.Title = ev.Title;
            eventFind.Location = ev.Location;
            eventFind.EventDate = ev.EventDate;
            eventFind.TicketPrice = ev.TicketPrice;
            eventFind.IsActive = ev.IsActive;

            _db.SaveChanges( );
            return ev;
        }
        public Event? ChangeSome (int id, EventPatch ev)
        {
            var eventFind = _db.Events.FirstOrDefault(i => i.Id == id);
            if (eventFind == null) return null;
            if(ev.Title !=null) eventFind.Title = ev.Title;
            if (ev.Location != null) eventFind.Location = ev.Location;
            if (ev.EventDate != null) eventFind.EventDate = ev.EventDate.Value;
            if (ev.TicketPrice != null) eventFind.TicketPrice = ev.TicketPrice.Value;
            if (ev.IsActive != null) eventFind.IsActive = ev.IsActive.Value;

            _db.SaveChanges( );
            return eventFind;
        }
        public bool Delete(int id)
        {
            try
            {
                var eventFind = _db.Events.FirstOrDefault(i => i.Id == id);
                _db.Events.Remove(eventFind);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }
    }
}
