import { ToDo } from './todo';
export class Database {
  tasks: ToDo[] = [];
  user = 'Hitesh';
  constructor() {
    this.tasks.push({ action: 'Wireframe Design', done: false });
    this.tasks.push({ action: 'Static UI Design', done: false });
    this.tasks.push({ action: 'Backend Preparation', done: false });
  }
}
