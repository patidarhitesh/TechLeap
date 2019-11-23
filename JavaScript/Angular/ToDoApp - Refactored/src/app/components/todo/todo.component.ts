import { Component, OnInit } from '@angular/core';
import { Model } from '../../Model/model';
import { ToDo } from '../../Model/todo';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {
  num = 231234.3443;
  data: ToDo[];
  source: Model;
  name: string;

  pendingTasks: number;
  constructor() {
    this.source = new Model();
    this.data = this.source.tasks;
    console.log(this.data);
  }
  // tslint:disable-next-line: variable-name
  updateNumber(no_tasks: number) {
    this.pendingTasks = no_tasks;
  }

  getUserName() {
    return this.source.user;
  }
  addTask(task: string) {
    if (task !== undefined && task !== '') {
      this.data.push({ action: task, done: false });
      this.data = [...this.data]; // Spread Operator
    }
  }

  ngOnInit() {}
}
