﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace Entities
{
    //The class "Note" will be acting as the data model for the Note Table in the database. 
    public class Note
    {
        /*
	 * This class should have nine fields
	 * (noteId,noteTitle,noteContent,noteStatus,createdAt,
	 * category,reminder,user, createdBy). Out of these nine fields, the field noteId
	 * should be primary key and auto-generated. The value of createdAt should not be
	 * accepted from the user but should be always initialized with the system date.
	 * annotate category, reminder and user field with [JsonIgnore].
	 */
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public string NoteStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public int ReminderId { get; set; }
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        [JsonIgnore]
        public Reminder Reminder { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
