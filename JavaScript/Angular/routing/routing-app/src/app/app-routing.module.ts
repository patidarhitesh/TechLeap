import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from '../app/components/home/home.component';
import { ContactComponent } from '../app/components/contact/contact.component';
import { EmployeeComponent } from '../app/components/employee/employee.component';
import { PagenotfoundComponent } from '../app/components/pagenotfound/pagenotfound.component';
import { EmployeedetailsComponent } from './components/employee/employeedetails/employeedetails.component';
import { AddEmployeeComponent } from './components/employee/add-employee/add-employee.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { RouteguardService } from './routeguard.service';
const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [RouteguardService]
  },
  {
    path: 'contact',
    component: ContactComponent,
    canActivate: [RouteguardService]
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'employees',
    component: EmployeeComponent,
    canActivate: [RouteguardService],
    children: [
      {
        path: 'create',
        component: AddEmployeeComponent,
        outlet: 'details'
      },
      {
        path: ':id',
        component: EmployeedetailsComponent,
        outlet: 'details'
      }
    ]
  },

  {
    path: '',
    redirectTo: 'register',
    pathMatch: 'full'
  },
  {
    path: '**',
    component: PagenotfoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
