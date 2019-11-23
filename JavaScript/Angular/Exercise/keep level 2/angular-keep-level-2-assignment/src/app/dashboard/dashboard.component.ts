import { Component, OnInit } from '@angular/core';

import { Note } from './../note';
import { NotesService } from '../services/notes.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  errMessage: string;
  note: Note = new Note();
  notes: Array<Note>;

  constructor(private notesService: NotesService) {}

  ngOnInit() {
    this.notesService.getNotes().subscribe(
      t => {
        if (t) {
          this.notes = t;
        } else {
          this.errMessage = 'We are unable to retreive notes list.';
        }
      },
      () => {
        this.errMessage = 'Http failure response : 404 Not Found';
      }
    );
  }

  addNote() {
    if (!this.note.text || !this.note.title) {
      this.errMessage = 'Title and Text both are required fields';
      return;
    }

    this.notesService.addNote(this.note).subscribe(
      t => {
        if (t) {
          this.notes.push(this.note);
          this.note = new Note();
        } else {
          this.errMessage = 'We are unable to add the selected note.';
        }
      },
      () => {
        this.errMessage = 'Http failure response : 404 Not Found';
      }
    );
  }
}
