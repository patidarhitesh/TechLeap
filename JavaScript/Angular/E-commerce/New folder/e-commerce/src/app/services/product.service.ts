import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../product';

import { Subject, Observable, throwError } from 'rxjs';
import { tap, map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = 'http://localhost:3000/products/';
  bearerToken: string;
  products: Array<Product>;
  token: any;
  prodId: any;
  selectedProd: any;
  router: any;
  cart: any;
  checkoutProd: any;
  total = 0;
  CartSubject: Subject<Product> = new Subject();
  removeSubject: Subject<Product> = new Subject();
  checkoutSubject: Subject<Product> = new Subject();
  prodSubject: BehaviorSubject<Array<Product>>;
 checkSubject: BehaviorSubject<Array<Product>>;
  productAdded: Subject<any> = new Subject();
  cartAdded: BehaviorSubject<Array<Product>>;
  carturl = 'http://localhost:3000/cart';
  constructor(
    private httpClient: HttpClient,
    private authService: AuthenticationService
  ) {
    this.products = [];
    this.prodSubject = new BehaviorSubject(this.products);
    this.cart = [];
    this.cartAdded = new BehaviorSubject(this.cart);
    this.checkoutProd = [];
    this.checkSubject = new BehaviorSubject(this.checkoutProd);
  }

  fetch() {
    return this.httpClient
      .get<Array<Product>>('http://localhost:3000/products')
      .subscribe(
        data => {
          this.products = data;
          this.prodSubject.next(this.products);
        },
        err => {}
      );
  }
  getProducts(): BehaviorSubject<Array<Product>> {
    this.fetch();

    return this.prodSubject;
  }

  details(item) {
    return this.httpClient
      .get<Array<Product>>('http://localhost:3000/products', {
        headers: new HttpHeaders().set('Authorization', `Bearer ${this.token}`)
      })
      .subscribe(data => {
        let num = 0;
        if (data.some(prod => prod.id === item.id)) {
          for (num = 0; num < data.length; num++) {
            if (data[num].id === item.id) {
              this.prodId = data[num].id;

              localStorage.setItem('id', this.prodId.toString());
            }
          }
        }
      });
  }

  getProdById(id): Observable<any> {
    return this.httpClient
      .get(`${this.baseUrl}\\${id}`, { observe: 'response' })
      .pipe(catchError(err => throwError(err)));
  }

  addToCart(product: {
    id: number;
    name: string;
    price: number;
    description: string;
    manufacturer: string;
  }) {
    return this.httpClient.post('http://localhost:3000/cart', product).pipe(
      map(res => {
        console.log('map');

        // tslint:disable-next-line: no-string-literal
        // res['name'] = res['name'].toUpperCase();
        // return res;
      }),
      tap(x => this.productAdded.next(x))
    );
  }
  fetchCart() {
    return this.httpClient
      .get<Array<Product>>('http://localhost:3000/cart')
      .subscribe(
        data => {
          this.cart = data;
          this.cartAdded.next(this.cart);
        },
        err => {}
      );
  }
  getCart(): BehaviorSubject<Array<Product>> {
    this.fetchCart();

    return this.cartAdded;
  }
  removeCart(product) {
    console.log(`http://localhost:3000/cart/${product.id}`);
    return this.httpClient
      .delete(`http://localhost:3000/cart/${product.id}`)
      .subscribe();
  }
  inCheckout(prod) {
    for (let i = 0; i < this.cart.length; i++) {
      return this.httpClient
        .post(`http://localhost:3000/checkout`, prod)
        .subscribe();
    }
  }
  checkout() {
    for (let i = 0; i < this.cart.length; i++) {
      this.inCheckout(this.cart[i]);
      return this.httpClient
        .delete(`http://localhost:3000/cart/${this.cart[i].id}`)
        .subscribe();
    }
  }
  fetchCheckout() {
    return this.httpClient
      .get<Array<Product>>('http://localhost:3000/checkout')
      .subscribe(
        data => {
          this.checkoutProd = data;
          this.checkSubject.next(this.checkoutProd);
        },
        err => {}
      );
  }
  getCheckout(): BehaviorSubject<Array<Product>> {
    this.fetchCheckout();

    return this.checkSubject;
  }
}
