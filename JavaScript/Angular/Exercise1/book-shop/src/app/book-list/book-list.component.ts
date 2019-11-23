import { Component, OnInit, ViewChild } from '@angular/core';
import { BookService } from '../services/book.service';
import { Model } from '../Model/model';
import { Book } from '../Model/book';
import { MatTable } from '@angular/material';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: any = [];
  
  @ViewChild('table', { static: false }) table: MatTable<any>;
  displayedColumns: string[] = ['index', 'action', 'done'];
  data: Book[];
  dataCopy: any = [];
  source: Model;
  fav: Book[] = [];

  constructor(private service: BookService) {
    this.source = new Model();
    this.data = this.source.entry;
    this.dataCopy = this.source.entry;
    console.log(this.data);
  }

  // addToCart(task) {
  //   this.service.addToCart(task);
  // }

  ngOnInit() {}
}
