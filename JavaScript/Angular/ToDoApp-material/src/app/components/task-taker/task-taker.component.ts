import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';

@Component({
  selector: 'app-task-taker',
  templateUrl: './task-taker.component.html',
  styleUrls: ['./task-taker.component.css']
})
export class TaskTakerComponent implements OnInit {
  constructor(private service: TaskService) {}

  addTask(task) {
    this.service.addTaskToList(task);
  }
  ngOnInit() {}
}
