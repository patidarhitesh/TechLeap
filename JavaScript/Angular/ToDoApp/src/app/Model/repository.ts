import { ToDo } from './todo';
import { Model } from './model';

export class ToDoRepostiory {
  todos: Model;
  data: ToDo[];
  constructor() {
    this.todos = new Model();
  }
  getToDoList() {
      this.data = this.todos.tasks;
  }
}
