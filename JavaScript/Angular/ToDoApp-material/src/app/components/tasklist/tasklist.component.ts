import { Component, OnInit, ViewChild } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { MatTable } from '@angular/material';

@Component({
  selector: 'app-tasklist',
  templateUrl: './tasklist.component.html',
  styleUrls: ['./tasklist.component.css']
})
export class TasklistComponent implements OnInit {
  tasks: any = [];
  @ViewChild('table', { static: false }) table: MatTable<any>;
  displayedColumns: string[] = ['index', 'action', 'done'];
  constructor(private service: TaskService) {
    console.log(service.getTaskList());
    this.tasks = [...service.getTaskList()];
  }

  ngOnInit() {
    this.service.taskSubject.subscribe(t => {
      // console.log('haha'+t);
      // tslint:disable-next-line: prefer-const
      let { action, done } = t;
      this.tasks.push({ action, done });
      // t = this.tasks;
      this.table.renderRows();
    });
  }
}
