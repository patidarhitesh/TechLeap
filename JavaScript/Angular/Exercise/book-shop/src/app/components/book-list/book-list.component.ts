import { Component, OnInit } from '@angular/core';
import { Model } from '../../Model/model';
import { Book } from '../../Model/book';
import { BooksService } from '../../services/books.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  data: Book[];
  dataCopy: Book[];
  source: Model;
  fav: Book[] = [];
  selected;
  filter: any;

  constructor(private service: BooksService) {
    this.source = new Model();
    this.data = this.source.entry;
    this.dataCopy = this.source.entry;

    console.log(this.selected);
    // console.log(this.data);
  }
  search(value: string) {
    this.data = this.dataCopy.filter(
      t =>
        t.category.toUpperCase().includes(value) ||
        t.author.toUpperCase().includes(value) ||
        t.title.toUpperCase().includes(value) ||
        t.price + '' === value
    );
  }

  addBook(book) {
    console.log(book);
    this.service.addBookToCart(book);
  }

  ngOnInit() {}
}
