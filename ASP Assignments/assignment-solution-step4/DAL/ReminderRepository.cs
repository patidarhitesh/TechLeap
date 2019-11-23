using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class ReminderRepository : IReminderRepository
    {
        private readonly KeepDbContext context;
        public ReminderRepository(KeepDbContext dbContext)
        {
            context = dbContext;
        }
        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            context.Reminders.Add(reminder);
            context.SaveChanges();
            return reminder;
        }
        //This method should be used to delete an existing reminder.
        public bool DeletReminder(int reminderId)
        {
            Reminder r = context.Reminders.Find(reminderId);

            context.Reminders.Remove(r);
            context.SaveChanges();
            //if (context.SaveChanges() > 0)
            //{
            return true;
            //}
            //return false;
        }
        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            List<Reminder> rem = context.Reminders.Where(r => r.CreatedBy == userId).ToList();
            return rem;
        }
        //This method should be used to get a reminder by reminderId.
        public Reminder GetReminderById(int reminderId)
        {
            return context.Reminders.Find(reminderId);
        }
        // This method should be used to update a existing reminder.
        public bool UpdateReminder(Reminder reminder)
        {
            context.Entry<Reminder>(reminder).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return true;
        }
    }
}
