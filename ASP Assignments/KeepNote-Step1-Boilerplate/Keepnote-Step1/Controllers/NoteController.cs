using Keepnote_Step1.Models;
using Keepnote_Step1.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Keepnote_Step1.Controllers
{
    public class NoteController : Controller
    {
        /*
          * From the problem statement, we can understand that the application
          * requires us to implement the following functionalities.
          * 
          * 1. display the list of existing notes from the collection. Each note 
          *    should contain Note Id, title, content, status and created date.
          * 2. Add a new note which should contain the note id, title, content and status.
          * 3. Delete an existing note.
      */

        /* 
         * Retrieve the NoteRepository object from the dependency Container through constructor Injection.
         */
        private readonly INoteRepository repo;
        public NoteController(INoteRepository noteRepo)
        {
            repo = noteRepo;
        }

        /*Define a handler method to read the existing notes by calling the GetNotes() method 
         * of the NoteRepository class and pass to view. it should map to the default URL i.e. "/" */
        [Route("")]
        public IActionResult Index()
        {

            return View(repo.GetNotes());
        }

        /*Define a handler method which will read the Note data from request parameters and
         * save the note by calling the AddNote() method of NoteRepository class. Please note 
         * that the createdAt field should always be auto populated with system time and should not be accepted 
         * from the user. Also, after saving the note, it should show the same along with existing 
         * notes.  
        */
        [HttpGet]
        [Route("addnote")]
        public IActionResult Create()
        {
            //ViewData["notelist"] = repo.GetNotes();
            return View();
        }
        [HttpPost]
        [Route("addnote")]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                note.CreatedAt = DateTime.Now.ToString("yyyy-MM-dd");
                repo.AddNote(note);               
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(note);
            }
        }

        /* Define a handler method to delete an existing note by calling the DeleteNote() method 
         * of the NoteRepository class
        */
        [HttpGet]
        [Route("Remove/{noteId}")]
        public IActionResult Delete(int noteId, int z)
        {
            var note = repo.GetNotes();
            var n = note.Find(e => e.NoteId == noteId);
            return View(n); ;
        }

        [HttpPost]
        [Route("Remove/{noteId}")]
        public IActionResult Delete(int noteId)
        {
            repo.DeletNote(noteId);
            return RedirectToAction("Index");
        }

    }
}