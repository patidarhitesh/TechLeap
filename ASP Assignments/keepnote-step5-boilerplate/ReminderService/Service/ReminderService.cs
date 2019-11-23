using System;
using System.Collections.Generic;
using System.Linq;
using ReminderService.Exceptions;
using ReminderService.Models;
using ReminderService.Repository;

namespace ReminderService.Service
{
    public class ReminderService : IReminderService
    {
       
        private readonly IReminderRepository reminderRepo;

        public ReminderService(IReminderRepository reminderRepository)
        {
            reminderRepo = reminderRepository;
        }

        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            Reminder r = reminderRepo.GetReminderById(reminder.Id);
            if (r == null)
            {
                return reminderRepo.CreateReminder(reminder);
            }
            else
            {
                throw new ReminderNotCreatedException("This reminder already exists");
            }
        }

        //This method should be used to delete an existing reminder.
        public bool DeleteReminder(int reminderId)
        {
            Reminder reminder1 = reminderRepo.GetReminderById(reminderId);
            if (reminder1 != null)
            {
                return reminderRepo.DeleteReminder(reminderId);
            }
            else
            {
                throw new ReminderNotFoundException($"This reminder id not found");
            }
        }

        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            
            if (reminderRepo.GetAllRemindersByUserId(userId) != null)
            {
                return reminderRepo.GetAllRemindersByUserId(userId);
            }
             else
            {
                throw new ReminderNotFoundException("This reminder id not found");
            }
        }
        //This method should be used to get a reminder by reminderId.
        public Reminder GetReminderById(int reminderId)
        {
            var reminder1 = reminderRepo.GetReminderById(reminderId);

            if (reminder1 != null)
            {
                return reminder1;
            }
            else
            {
                throw new ReminderNotFoundException($"This reminder id not found");
            }
        }

        // This method should be used to update a existing reminder.
        public bool UpdateReminder(int reminderId, Reminder reminder)
        {
            var reminder1 = reminderRepo.GetReminderById(reminderId);

            if (reminder1 != null)
            {
                return reminderRepo.UpdateReminder(reminderId,reminder1);
            }
            else
            {
                throw new ReminderNotFoundException($"This reminder id not found");
            }
        }
    }
}
