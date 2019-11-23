//using Microsoft.AspNetCore.Mvc;

using Keepnote.Models;
using Keepnote.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Keepnote.Controllers
{
    public class NoteController : Controller
    {
        /*
	     From the problem statement, we can understand that the application
	     requires us to implement the following functionalities.
	     1. display the list of existing notes from the collection. Each note 
	        should contain Note Id, title, content, status and created date.
	     2. Add a new note which should contain the title, content and status.
	     3. Delete an existing note.
         4. Update an existing Note.
	    */

        //Inject the noteRepository instance through constructor injection.
        private readonly INoteRepository repo;
        public NoteController(INoteRepository noteRepo)
        {
            repo = noteRepo;
        }

        /*
      * Define a handler method to read the existing notes from the database and add
      * it to the ModelMap which is an implementation of Map, used when building
      * model data for use with views. it should map to the default URL i.e. "/index"
      */
        //[Route("")]
        public IActionResult Index()
        {
            return View(repo.GetAllNotes());
        }
        /*
         * Define a handler method which will read the NoteTitle, NoteContent,
         * NoteStatus from request parameters and save the note in note table in
         * database. Please note that the CreatedAt should always be auto populated with
         * system time and should not be accepted from the user. Also, after saving the
         * note, it should show the same along with existing messages. Hence, reading
         * note has to be done here again and the retrieved notes object should be sent
         * back to the view. This handler method should map to the URL "/create".
         */
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            //ViewData["notelist"] = repo.GetNotes();
            return View();
        }
        [HttpPost]
        [Route("create")]
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

        /*
         * Define a handler method which will read the NoteId from request parameters
         * and remove an existing note by calling the deleteNote() method of the
         * NoteRepository class.".
         */
        [HttpGet]
        [Route("Remove/{noteId}")]
        public IActionResult Delete(int noteId, int z)
        {
            var note = repo.GetAllNotes();
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

        /*
         * Define a handler method which will update the existing note.
         */

        [HttpGet]
        [Route("Edit/{noteId}")]
        public IActionResult Edit(Note note, int a)
        {
           
            return View(note); 
        }

        [HttpPost]
        [Route("Edit/{noteId}")]
        public IActionResult Edit(Note note)
        {
            note.CreatedAt = DateTime.Now.ToString("yyyy-MM-dd");
            repo.UpdateNote(note);
            return RedirectToAction(nameof(Index));
        }

    }
}