using System;
using System.Collections.Generic;
using NoteService.Exceptions;
using NoteService.Models;
using NoteService.Repository;

namespace NoteService.Service
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepo;

        /*
         Use constructor Injection to inject all required dependencies.
             */
        public NoteService(INoteRepository repository)
        {
            noteRepo = repository;
        }

        /*
	     * This method should be used to save a new note.
	     */
        public bool CreateNote(Note note)
        {
            return noteRepo.CreateNote(note);

        }
        /* This method should be used to delete an existing note. */
        public bool DeleteNote(string userId, int noteId)
        {

            if (noteRepo.DeleteNote(userId, noteId))
            {
                return true;
            }
            else
            {
                throw new NoteNotFoundExeption($"NoteId {noteId} for user Sachin does not exist");
            }
        }



        /*
         * This method should be used to get all note by userId.
         */
        public List<Note> GetAllNotesByUserId(string userId)
        {
            return noteRepo.FindAllNotesByUser(userId);
        }

        //This method should be used to update a existing note.
        public Note UpdateNote(int noteId, string userId, Note note)
        {

            if (noteRepo.UpdateNote(noteId, userId, note))
            {

                return note;
            }
            else
            {
                throw new NoteNotFoundExeption("HJBD");
            }

        }
    }
}
