using prakt6_Leshukov.Models;

namespace prakt6_Leshukov
{
    public class EventService
    {
        private WebApiDatabaseContext _db = DBServices.Instance.Context;
        public List<Event> GetAll ()
        {
            List<Event> events = new List<Event>( );
            foreach (var e in _db.Events)
                events.Add(e);
            return events;
        }
        public Event Get (int id)
        {
            var eventFind = _db.Events.Where(i => i.Id == id);
            return (Event)eventFind;
        }
        public void Create(Event ev)
        {
            ev.Id = 0;
            _db.Events.Add(ev);
            _db.SaveChanges( );
        }
        public Event? Change(int id,Event ev)
        {

            var eventFind = _db.Events.FirstOrDefault(i => i.Id == id);

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
            if (ev.IsActive != null) eventFind.IsActive = ev.IsActive;


            _db.SaveChanges( );
            return eventFind;
        }
    }
}
