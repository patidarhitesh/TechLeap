using System.Collections.Generic;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
   * Service classes are used here to implement additional business logic/validation
   * */
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepo;
        private readonly ICategoryRepository categoryRepo;
        private readonly IReminderRepository reminderRepo;
        /*
         Use constructor Injection to inject all required dependencies.
             */
        public NoteService(INoteRepository repository, ICategoryRepository category, IReminderRepository reminder)
        {
            noteRepo = repository;
            categoryRepo = category;
            reminderRepo = reminder;
        }

        /*
	     * This method should be used to save a new note.
	     */
        public Note CreateNote(Note note)
        {
            var category1 = categoryRepo.GetCategoryById(note.CategoryId);
            var reminder1 = reminderRepo.GetReminderById(note.ReminderId);

            if (category1 != null && reminder1 != null)
            {
                return noteRepo.CreateNote(note);
            }
            else if (category1 == null)
            {
                throw new CategoryNotFoundException($"Category with id: {note.CategoryId} does not exist");
            }
            else
            {
                throw new ReminderNotFoundException($"Reminder with id: {note.ReminderId} does not exist");
            }
        }
        /* This method should be used to delete an existing note. */
        public bool DeleteNote(int noteId)
        {
            return noteRepo.DeleteNote(noteId);
        }

        /*
	     * This method should be used to get all note by userId.
	     */
        public List<Note> GetAllNotesByUserId(string userId)
        {
            return noteRepo.GetAllNotesByUserId(userId);
        }

        //This method should be used to get a note by noteId.
        public Note GetNoteByNoteId(int noteId)
        {
            var note1 = noteRepo.GetNoteByNoteId(noteId);

            if (note1 != null)
            {
                return note1;
            }
            else
            {
                throw new NoteNotFoundException($"Note with id: {noteId} does not exist");
            }
        }
        //This method should be used to update a existing note.
        public bool UpdateNote(int noteId, Note note)
        {
            var note1 = noteRepo.GetNoteByNoteId(noteId);
            var category1 = categoryRepo.GetCategoryById(note.CategoryId);
            var reminder1 = reminderRepo.GetReminderById(note.ReminderId);

            if (note1 != null && category1 != null && reminder1 != null)
            {
                return noteRepo.UpdateNote(note1);
            }
            if (note1 == null)
            {
                throw new NoteNotFoundException($"Note with id: {noteId} does not exist");
            }
            else if (category1 == null)
            {
                throw new CategoryNotFoundException($"Category with id: {note.CategoryId} does not exist");
            }
            else
            {
                throw new ReminderNotFoundException($"Reminder with id: {note.ReminderId} does not exist");
            }
        }
    }
}
