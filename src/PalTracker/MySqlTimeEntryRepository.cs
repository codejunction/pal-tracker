using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PalTracker
{

    public class MySqlTimeEntryRepository : ITimeEntryRepository
    {
        private readonly TimeEntryContext _timeEntryContext;
        public MySqlTimeEntryRepository(TimeEntryContext timeEntryContext)
        {
            _timeEntryContext = timeEntryContext;
        }
        public TimeEntry Create(TimeEntry timeEntry)
        {
            var recordToCreate = timeEntry.ToRecord();

            _timeEntryContext.TimeEntryRecords.Add(recordToCreate);
            _timeEntryContext.SaveChanges();

            return Find(recordToCreate.Id.Value);
        }
        public TimeEntry Find(long id)
        {
            return FindRecord(id).ToEntity();
        }
        public bool Contains(long id)
        {
            return _timeEntryContext.TimeEntryRecords.AsNoTracking().Any(t => t.Id == id);
        }
        public IEnumerable<TimeEntry> List()
        {
            return _timeEntryContext.TimeEntryRecords.AsNoTracking().Select(t => t.ToEntity());
        }
        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            var recordToUpdate = timeEntry.ToRecord();
            recordToUpdate.Id = id;

            _timeEntryContext.Update(recordToUpdate);
            _timeEntryContext.SaveChanges();

            return Find(id);
        }

        public void Delete(long id)
        {
            _timeEntryContext.TimeEntryRecords.Remove(FindRecord(id));
            _timeEntryContext.SaveChanges();
        }
        private TimeEntryRecord FindRecord(long id) =>
            _timeEntryContext.TimeEntryRecords.AsNoTracking().Single(t => t.Id == id);
    }
}