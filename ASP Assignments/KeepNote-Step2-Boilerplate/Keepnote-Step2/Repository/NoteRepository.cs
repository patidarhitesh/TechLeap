using System.Collections.Generic;
using System.Linq;
using Keepnote.Models;
using Microsoft.EntityFrameworkCore;

namespace Keepnote.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly KeepNoteContext context;
        public NoteRepository(KeepNoteContext KContext)
        {
            context = KContext;//dependency Injection
        }

        // Save the note in the database(note) table.
        public int AddNote(Note note)
        {
            //throw new System.NotImplementedException();
            context.Notes.Add(note);
            return context.SaveChanges();
        }
        //Remove the note from the database(note) table.
        public int DeletNote(int noteId)
        {
            Note note = context.Notes.Find(noteId);
            context.Notes.Remove(note);
            return context.SaveChanges();
        }
        
        //can be used as helper method for controller
        public bool Exists(int noteId)
        {
            var note =  context.Notes.Find(noteId);
            if(note != null)
            {
                return true;
            }
            return false;
        }

       /* retrieve all existing notes sorted by created Date in descending
        order(showing latest note first)*/
        public List<Note> GetAllNotes()
        {
            return context.Notes.ToList();
        }

        //retrieve specific note from the database(note) table
        public Note GetNoteById(int noteId)
        {
            return context.Notes.Find(noteId); ;
        }
        //Update existing note
        public int UpdateNote(Note note)
        {
            context.Entry<Note>(note).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
