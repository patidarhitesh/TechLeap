import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { EmployeeListComponent } from './modules/employee/employee-list/employee-list.component';
import { AdminComponent } from './modules/admin/admin/admin.component';
import { RouteguardService } from './routeguard.service';

const routes: Routes = [
  { path: 'home', component: HomeComponent,canActivate: [RouteguardService] },
  
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  {
    path: 'employees',
    loadChildren: './modules/employee/employee.module#EmployeeModule',
    canActivate: [RouteguardService]
  },
  { path: 'admin', component: AdminComponent,
  canActivate: [RouteguardService] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
