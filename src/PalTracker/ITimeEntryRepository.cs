using System.Collections.Generic;
namespace PalTracker
{
    public interface ITimeEntryRepository
    {
        TimeEntry Create(TimeEntry timeEntry);
        TimeEntry Find(int id);
        bool Contains(int id);
        IEnumerable<TimeEntry> List();
        TimeEntry Update(int id, TimeEntry timeEntry);
        void Delete(int id);

    }
}