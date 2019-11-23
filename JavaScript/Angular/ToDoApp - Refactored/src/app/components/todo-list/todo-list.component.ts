import {
  Component,
  OnInit,
  Input,
  Output,
  EventEmitter,
  DoCheck
} from '@angular/core';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {
  @Input() tasks = [];

  @Output() updatePendingTasks = new EventEmitter();
  constructor() {}

  ngOnInit() {
    console.log('onInit envoked.');
    let pendingTasks = this.tasks.filter(t => t.done === false).length;
    console.log(`Pending Tasks ${pendingTasks}`);
    this.updatePendingTasks.emit(pendingTasks);
  }
  ngOnChanges() {
    console.log('onChange envoked.');
    // Called before any other lifecycle hook. Use it to inject dependencies, but avoid any serious work here.
    // Add '${implements OnChanges}' to the class.
    this.update();
  }
  // ngDoCheck() {
    
  //   console.log('doCheck envoked.');
  //  //this.update();
  // }

  update() {
    let pendingTasks = this.tasks.filter(t => t.done === false).length;
    this.updatePendingTasks.emit(pendingTasks);
  }
}
