import { Component, OnInit, ViewChild } from '@angular/core';
import { BookService } from '../services/book.service';
import { MatTable } from '@angular/material';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  books: any = [];
  @ViewChild('table', { static: false }) table: MatTable<any>;
  displayedColumns: string[] = ['index', 'action', 'done'];
  constructor(private service: BookService) {
    console.log(service.getBookList());
    this.books = [...service.getBookList()];
  }

  ngOnInit() {
    // //this.service.booksubject.subscribe(t => {
    //   // console.log('haha'+t);
    //   // tslint:disable-next-line: prefer-const
    //  // let { action, done } = t;
    //   this.books.push({ action, done });
    //   // t = this.books;
    //   this.table.renderRows();
    // //});
  }

}
