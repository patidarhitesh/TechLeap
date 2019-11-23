import { Injectable } from '@angular/core';
import { Model } from '../Model/model';
import { Book } from '../Model/book';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  data: Book[] = [];
  db: Model;
  cart: any[] = [];
  total = 0;
  bookSubject: Subject<Book> = new Subject();
  bookSubject2: Subject<Book> = new Subject();
  bookSubject3: Subject<Book> = new Subject();
  constructor() {
    this.db = new Model();
  }

  addBookToCart(book) {
    // tslint:disable-next-line: prefer-const

    this.cart.push(book);
    this.bookSubject.next(book);
    // console.log(this.cart);
  }
  removeBookCart(book) {
    this.cart.splice(book, 1);
    console.log(this.cart);
    console.log('removeservices');

    this.bookSubject2.next(book);
    return this.cart;
  }
  checkout() {
    console.log('checkoutservice');
    for (let i of this.cart) {
      const found = this.data.some(i => this.cart.includes(i));

      if (found) {
        let n: number = this.data.indexOf(i);
        this.data[n].quantityAvailable -= 1;
      }
    }
    this.cart = [];
    this.bookSubject3.next();
    return this.cart;
  }
  getBookList() {
    // this.data = this.db.entry;
    // console.log(this.cart);

    return this.cart;
  }
}
