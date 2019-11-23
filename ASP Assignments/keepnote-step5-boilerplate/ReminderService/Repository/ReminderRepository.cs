using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using ReminderService.Models;

namespace ReminderService.Repository
{
    public class ReminderRepository:IReminderRepository
    {
        //define a private variable to represent ReminderContext
        private readonly ReminderContext context;
        public ReminderRepository(ReminderContext _context)
        {
            context = _context;
        }
        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            //reminder Id should be auto generated and must start from 201
            var list = context.Reminders.Find(_ => true).ToList();
            if (list.Count == 0)
            {
                reminder.Id = 201;
            }
            else
            {
                reminder.Id = list.Count + 201;
            }
            context.Reminders.InsertOne(reminder);
            return reminder;
        }
        //This method should be used to delete an existing reminder.
        public bool DeleteReminder(int reminderId)
        {
            var deleteResult = context.Reminders.DeleteOne(c => c.Id == reminderId);
            return deleteResult.DeletedCount > 0;
        }
        //This method should be used to get all reminders by userId
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            return context.Reminders.Find(c => c.CreatedBy == userId).ToList();
        }
        //This method should be used to get a reminder by reminderId
        public Reminder GetReminderById(int reminderId)
        {
            return context.Reminders.Find(c => c.Id == reminderId).FirstOrDefault();
        }
        // This method should be used to update an existing reminder.
        public bool UpdateReminder(int reminderId, Reminder reminder)
        {
            var filter = Builders<Reminder>.Filter.Where(c => c.Id == reminderId);
            var updateResult = context.Reminders.ReplaceOne(filter, reminder);
            return updateResult.MatchedCount > 0;
        }
    }
}
