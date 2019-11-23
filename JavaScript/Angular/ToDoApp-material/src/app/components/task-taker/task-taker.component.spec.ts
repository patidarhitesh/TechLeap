import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskTakerComponent } from './task-taker.component';

describe('TaskTakerComponent', () => {
  let component: TaskTakerComponent;
  let fixture: ComponentFixture<TaskTakerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskTakerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskTakerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
