using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class NoteRepository : INoteRepository
    {
        private readonly KeepDbContext context;
        public NoteRepository(KeepDbContext dbContext)
        {
            context = dbContext;
        }

        // This method should be used to save a new note.
        public Note CreateNote(Note note)
        {
            context.Notes.Add(note);
            context.SaveChanges();
            return note;
        }

        /* This method should be used to delete an existing note. */
        public bool DeleteNote(int noteId)
        {
            Note note = context.Notes.Find(noteId);
            context.Notes.Remove(note);
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        //* This method should be used to get all note by userId.
        public List<Note> GetAllNotesByUserId(string userId)
        {
            List<Note> notes = context.Notes.Where(n => n.CreatedBy == userId).ToList();
            return notes;
        }
        //This method should be used to get a note by noteId.
        public Note GetNoteByNoteId(int noteId)
        {
            return context.Notes.Find(noteId);
        }
        //This method should be used to update a existing note.
        public bool UpdateNote(Note note)
        {
            context.Entry<Note>(note).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return true;

        }
    }
}
