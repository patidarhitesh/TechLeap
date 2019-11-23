import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductListComponent } from '../../src/app/components//product-list/product-list.component';
import { LoginComponent } from '../../src/app/components//login/login.component';
import { RegisterComponent } from '../../src/app/components//register/register.component';
import { CartComponent } from '../../src/app/components/cart/cart.component';
import { ProductService } from './services/product.service';
import { AuthenticationService } from './services/authentication.service';
import { ProductComponent } from './components/product/product.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    LoginComponent,
    RegisterComponent,
    CartComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [ProductService, AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
