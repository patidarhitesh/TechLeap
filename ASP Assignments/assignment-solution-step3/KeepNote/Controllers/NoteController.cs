using Entities;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;

namespace KeepNote.Controllers
{
    /*
    * As in this assignment, we are working with creating RESTful web service, hence annotate
    * the class with [ApiController] annotation and define the controller level route as per REST Api standard.
    */
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        /*
        * NoteService should  be injected through constructor injection. Please note that we should not create service
        * object using the new keyword
        */
        
        private readonly INoteService service;
        public NoteController(INoteService noteService)
        {
            service = noteService;
        }

        /*
         * Define a handler method which will create a specific note by reading the
         * Serialized object from request body and save the note details in a Note table
         * in the database.Handle ReminderNotFoundException and
         * CategoryNotFoundException as well. please note that the userID
         * should be taken as the createdBy for the note.This handler method should
         * return any one of the status messages basis on different situations: 1.
         * 201(CREATED) - If the note created successfully. 2. 409(CONFLICT) - If the
         * noteId conflicts with any existing user
         * 
         * This handler method should map to the URL "/api/note" using HTTP POST method
         */

        [HttpPost]
  
        public IActionResult Post([FromBody]Note note)
        {
            try
            {
                return StatusCode(201, service.CreateNote(note));
            }
            catch (ReminderNotFoundException rnf)
            {
                return BadRequest(rnf.Message);
            }
            catch (CategoryNotFoundException cnf)
            {
                 return BadRequest(cnf.Message);
            }
            
        }

        /*
         * Define a handler method which will delete a note from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note deleted successfully from
         * database. 2. 404(NOT FOUND) - If the note with specified noteId is not found.
         * 
         * This handler method should map to the URL "/api/note/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid noteId without {}
         */
        [HttpDelete("{noteId}")]
        public IActionResult Delete(int noteId)
        {
            try
            {
                return Ok(service.DeleteNote(noteId));
            }
            catch (NoteNotFoundException nnf)
            {
                return BadRequest(nnf.Message);
            }
            

        }
        /*
         * Define a handler method which will update a specific note by reading the
         * Serialized object from request body and save the updated note details in a
         * note table in database handle ReminderNotFoundException,
         * NoteNotFoundException, CategoryNotFoundException as well. please note that
         * the userID should be taken as the createdBy for the note. This
         * handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note updated successfully. 2.
         * 404(NOT FOUND) - If the note with specified noteId is not found.
         * This handler method should map to the URL "/api/note/{id}" using HTTP PUT method.
         */
        [HttpPut("{noteId}")]
        public IActionResult Put(int noteId, [FromBody] Note note)
        {
            try
            {
                
                return Ok(service.UpdateNote(noteId, note));
            }
            catch (NoteNotFoundException nnf)
            {
                return StatusCode(404, $"Note with id: {noteId} does not exist");
            }
            catch (ReminderNotFoundException rnf)
            {
                return BadRequest(rnf.Message);
            }
            catch (CategoryNotFoundException cnf)
            {
                return BadRequest(cnf.Message);
            }
            

        }
        /*
         * Define a handler method which will get us the notes by a userId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note found successfully.
         * 
         * This handler method should map to the URL "/api/note/{userId}" using HTTP GET method
         */
        [HttpGet("{Id:int}")]
        
        public IActionResult Get(int Id)
        {
            try
            {
                return Ok(service.GetNoteByNoteId(Id));
            }
            catch (NoteNotFoundException cnf)
            {
                return NotFound(cnf.Message);//will generate 404
            }
            
        }
        [HttpGet("{Id}")]
        public IActionResult Get(string Id)
        {
            try
            {
                return Ok(service.GetAllNotesByUserId(Id));
            }
            catch (NoteNotFoundException cnf)
            {
                return NotFound(cnf.Message);//will generate 404
            }

        }
    }
}
