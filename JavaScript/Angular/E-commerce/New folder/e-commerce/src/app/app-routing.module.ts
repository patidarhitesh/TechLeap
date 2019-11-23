import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { ProductComponent } from './components/product/product.component';
import { CartComponent } from './components/cart/cart.component';
import { RouteguardService } from './can-activate-route.guard';

const routes: Routes = [
  {
    path: 'home',
    component: ProductListComponent
  },

  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'productlist',
    component: ProductListComponent
  },
  {
    path: 'productlist/:id',
    component: ProductComponent
  },
  {
    path: 'cart',
    component: CartComponent,
    canActivate: [RouteguardService]
  },

  { path: '', redirectTo: 'productlist', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
