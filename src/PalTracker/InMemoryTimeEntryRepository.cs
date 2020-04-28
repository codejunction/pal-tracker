using System.Collections.Generic;
using System.Linq;
namespace PalTracker{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
        private readonly IDictionary<int, TimeEntry> _inMemoryTimeEntry = new Dictionary<int, TimeEntry>(); 

        public TimeEntry Create(TimeEntry timeEntry){
            var inMemoryTimeEntryCountAsId = _inMemoryTimeEntry.Count+1;    
            timeEntry.Id = inMemoryTimeEntryCountAsId;      
            _inMemoryTimeEntry.Add(inMemoryTimeEntryCountAsId, timeEntry);
            return timeEntry;
         }
        public TimeEntry Find(int id){
            return _inMemoryTimeEntry[id];
        }
        public bool Contains(int id){
            return _inMemoryTimeEntry.ContainsKey(id);
        }
        public IEnumerable<TimeEntry> List(){
            return _inMemoryTimeEntry.Values.ToList();
        }
        public TimeEntry Update(int id, TimeEntry timeEntry){
            timeEntry.Id = id;
            _inMemoryTimeEntry[id] = timeEntry;
            return timeEntry;
        }
        public void Delete(int id){
            _inMemoryTimeEntry.Remove(id);
        }
    }
}