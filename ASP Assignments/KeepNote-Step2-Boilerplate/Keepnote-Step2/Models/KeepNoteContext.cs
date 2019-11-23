﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Keepnote.Models
{

    public class KeepNoteContext : DbContext
    {
        /*
         This class should be used as DbContext to speak to database and should make the use of Code first approach.
         It should autogenerate the database based upon the model class in your application
          */
        public KeepNoteContext() { }
        public KeepNoteContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Note> Notes { get; set; }
    }
}
