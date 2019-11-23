import { Component, OnInit } from '@angular/core';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {
  course = 'Tech Leap .NET Full Stack';
  cities = ['Delhi', 'pune', 'Indore'];
  color = '#fafafa';
  hidden = true;

  students = [
    {
      Id: 101,
      name: 'Hriday',
      city: 'Jaipur',
      Gender: 'Male'
    },
    {
      Id: 102,
      name: 'Karandeep',
      city: 'Patiala',
      Gender: 'Male'
    },
    {
      Id: 103,
      name: 'Maliha',
      city: 'Jaipur',
      Gender: 'Female'
    },
    {
      Id: 103,
      name: 'Shivangi',
      city: 'Wasseypur',
      Gender: 'Female'
    }
  ];
  constructor() {}

  ngOnInit() {}
}
