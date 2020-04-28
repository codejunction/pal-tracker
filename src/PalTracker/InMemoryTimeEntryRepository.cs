using System.Collections.Generic;
using System.Linq;
namespace PalTracker{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
        private readonly IDictionary<long, TimeEntry> _inMemoryTimeEntry = new Dictionary<long, TimeEntry>(); 

        public TimeEntry Create(TimeEntry timeEntry){
            var inMemoryTimeEntryCountAsId = _inMemoryTimeEntry.Count+1;    
            timeEntry.Id = inMemoryTimeEntryCountAsId;      
            _inMemoryTimeEntry.Add(inMemoryTimeEntryCountAsId, timeEntry);
            return timeEntry;
         }
        public TimeEntry Find(long id){
            return _inMemoryTimeEntry[id];
        }
        public bool Contains(long id){
            return _inMemoryTimeEntry.ContainsKey(id);
        }
        public IEnumerable<TimeEntry> List(){
            return _inMemoryTimeEntry.Values.ToList();
        }
        public TimeEntry Update(long id, TimeEntry timeEntry){
            timeEntry.Id = id;
            _inMemoryTimeEntry[id] = timeEntry;
            return timeEntry;
        }
        public void Delete(long id){
            _inMemoryTimeEntry.Remove(id);
        }
    }
}