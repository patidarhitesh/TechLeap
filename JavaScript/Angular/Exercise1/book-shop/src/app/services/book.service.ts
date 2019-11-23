import { Injectable } from '@angular/core';
import { Model } from '../Model/model';
import { Book } from '../Model/book';
import { Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class BookService {
  data: Book[] = [];
  db: Model;
  taskSubject: Subject<Book> = new Subject();
  constructor() {
    this.db = new Model();
  }
  getBookList() {
    this.data = this.db.entry;
    return this.data;
  }
  addToCart(a: any, b: any, c: any, d: any, e: any, f: any, g: any, id: number) {
    const t = {  author: a,
      category: b,
      quantityAvailable: c,
      id: d,
      price: e,
      title: f,
      publishingDate: g,
      cart: false };

    this.data.push(t);
    this.taskSubject.next(t);
    console.log(this.data);
  }
}
