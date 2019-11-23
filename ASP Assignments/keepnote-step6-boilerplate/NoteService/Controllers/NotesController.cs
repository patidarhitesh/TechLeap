using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteService.Exceptions;
using NoteService.Models;
using NoteService.Service;

namespace NoteService.Controllers
{
    /*
      As in this assignment, we are working with creating RESTful web service to create microservices, hence annotate
      the class with [ApiController] annotation and define the controller level route as per REST Api standard.
  */
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    /*
      As in this assignment, we are working with creating RESTful web service to create microservices, hence annotate
      the class with [ApiController] annotation and define the controller level route as per REST Api standard.
  */
    public class NotesController : Controller
    {

        /*
        NoteService should  be injected through constructor injection. Please note that we should not create service
        object using the new keyword
        */
        private readonly INoteService service;
        public NotesController(INoteService noteService)
        {
            service = noteService;
        }

        /*
	    * Define a handler method which will create a specific note by reading the
	    * Serialized object from request body and save the note details in the
	    * database.This handler method should return any one of the status messages
	    * basis on different situations: 
	    * 1. 201(CREATED) - If the note created successfully. 
	    
	    * This handler method should map to the URL "/api/note/{userId}" using HTTP POST method
	    */

        [HttpPost("{userId}")]

        public IActionResult Post([FromBody]Note note)
        {
            try
            {
                service.CreateNote(note);
                return StatusCode(201, note);
            }
            catch (NoteAlreadyExistsException rnf)
            {
                return Conflict(rnf.Message);
            }


        }

        /*
         * Define a handler method which will delete a note from a database.
         * This handler method should return any one of the status messages basis 
         * on different situations: 
         * 1. 200(OK) - If the note deleted successfully from database. 
         * 2. 404(NOT FOUND) - If the note with specified noteId is not found.
         *
         * This handler method should map to the URL "/api/note/{userId}/{noteId}" using HTTP Delete
         */
        [HttpDelete("{userId}/{noteId}")]
        public IActionResult Delete(string userId, int noteId)
        {
            try
            {
                return Ok(service.DeleteNote(userId, noteId));
            }
            catch (NoteNotFoundExeption nnf)
            {
                return NotFound(nnf.Message);
            }


        }
        /*
         * Define a handler method which will update a specific note by reading the
         * Serialized object from request body and save the updated note details in a
         * database. 
         * This handler method should return any one of the status messages
         * basis on different situations: 
         * 1. 200(OK) - If the note updated successfully.
         * 2. 404(NOT FOUND) - If the note with specified noteId is not found.
         * 
         * This handler method should map to the URL "/api/note/{userId}/{noteId}" using HTTP PUT method.
         */
        [HttpPut("{userId}/{noteId}")]
        public IActionResult Put(int noteId, string UserId, [FromBody] Note note)
        {
            try
            {
                return Ok(service.UpdateNote(noteId, UserId, note));
            }
            catch (NoteNotFoundExeption nnf)
            {
                return NotFound($"NoteId {noteId} for user {UserId} does not exist");
            }
        }

        /*
         * Define a handler method which will get us the all notes by a userId.
         * This handler method should return any one of the status messages basis on
         * different situations: 
         * 1. 200(OK) - If the note found successfully. 
         * 
         * This handler method should map to the URL "/api/note/{userId}" using HTTP GET method
         */
        [HttpGet("{Id}")]
        public IActionResult Get(string Id)
        {
            try
            {
                return Ok(service.GetAllNotesByUserId(Id));
            }
            catch (NoteNotFoundExeption cnf)
            {
                return NotFound(cnf.Message);//will generate 404
            }

        }
        /*
         * Define a handler method which will show details of a specific note created by specific 
         * user. This handler method should return any one of the status messages basis on
         * different situations: 
         * 1. 200(OK) - If the note found successfully. 
         * 2. 404(NOT FOUND) - If the note with specified noteId is not found.
         * This handler method should map to the URL "/api/note/{userId}/{noteId}" using HTTP GET method
         * where "id" should be replaced by a valid reminderId without {}
         * 
         */

        [HttpGet("{userId}/{noteId:int}")]

        public IActionResult Get(string userId, int noteId)
        {
            try
            {
                return Ok(service.GetAllNotesByUserId(userId).Find(n => n.Id == noteId));
            }
            catch (NoteNotFoundExeption cnf)
            {
                return NotFound(cnf.Message);//will generate 404
            }

        }

    }
}