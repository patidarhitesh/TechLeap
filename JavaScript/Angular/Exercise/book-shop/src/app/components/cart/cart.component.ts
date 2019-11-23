import { Component, OnInit } from '@angular/core';
import { BooksService } from '../../services/books.service';
import { MatTable } from '@angular/material';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  books: any = [];
  total: number;

  constructor(private service: BooksService) {
    console.log(service.getBookList());
    this.books = [...service.getBookList()];
    console.log(this.books);
  }
  removeBook(book) {
    console.log('remove');
    this.service.removeBookCart(book);
  }
  ngDoCheck(): void {
    this.total = 0;
    this.books.forEach(element => {
      this.total = this.total + element.price;
    });
  }
  checkout() {
    this.service.checkout();
  }

  ngOnInit() {
    this.service.bookSubject.subscribe(t => {
      // console.log('haha'+t);
      // tslint:disable-next-line: prefer-const
      // tslint:disable: prefer-const
      let {
        id,
        title,
        author,
        category,
        quantityAvailable,
        publishingDate,
        price,
        cart
      } = t;
      this.books.push({
        id,
        title,
        author,
        category,
        quantityAvailable,
        publishingDate,
        price,
        cart
      });
      this.books = [...this.books];
      // t = this.tasks;
    });
    this.service.bookSubject2.subscribe(t => {
      // console.log('haha'+t);
      // tslint:disable-next-line: prefer-const
      // tslint:disable: prefer-const
      let {
        id,
        title,
        author,
        category,
        quantityAvailable,
        publishingDate,
        price,
        cart
      } = t;
      this.books.splice(t, 1);
      this.books = [...this.books];
      // t = this.tasks;
    });
    this.service.bookSubject3.subscribe(() => {
      this.books = [];
      this.books = [...this.books];
    });
  }
}
//
