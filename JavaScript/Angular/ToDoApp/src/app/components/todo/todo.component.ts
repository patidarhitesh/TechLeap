import { Component, OnInit } from '@angular/core';
import { Model } from '../../Model/model';
import { ToDo } from '../../Model/todo';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {
  data: ToDo[];
  source: Model;
  name: string;
  constructor() {
    this.source = new Model();
    this.data = this.source.tasks;
    console.log(this.data);
  }
  getUserName() {
    return this.source.user;
  }
  addTask(task: string) {
    if (task !== undefined && task !== '') {
      this.data.push({ action: task, done: false });
    }
  }

  ngOnInit() {}
}
