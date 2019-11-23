using System.Collections.Generic;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
   * Service classes are used here to implement additional business logic/validation
   * */
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository reminderRepo;
        /*
        Use constructor Injection to inject all required dependencies.
        */
        public ReminderService(IReminderRepository reminderRepository)
        {
            reminderRepo = reminderRepository;
        }

        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            return reminderRepo.CreateReminder(reminder);
        }

        //This method should be used to delete an existing reminder.
        public bool DeletReminder(int reminderId)
        {
            Reminder reminder1 = reminderRepo.GetReminderById(reminderId);
            if (reminder1 != null)
            {
                return reminderRepo.DeletReminder(reminderId);
            }
            else
            {
                throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
            }
        }

        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            return reminderRepo.GetAllRemindersByUserId(userId);
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
                throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
            }
        }

        // This method should be used to update a existing reminder.
        public bool UpdateReminder(int reminderId,Reminder reminder)
        {
            var reminder1 = reminderRepo.GetReminderById(reminderId);

            if (reminder1 != null)
            {
                return reminderRepo.UpdateReminder(reminder1);
            }
            else
            {
                throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
            }
        }
    }
}
