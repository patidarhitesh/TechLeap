import { Component, OnInit } from '@angular/core';
import { Model } from '../../Model/model';
import { Movie } from '../../Model/movie';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  data: Movie[];
  source: Model;
  fav: Movie[] = [];

  constructor() {
    this.source = new Model();
    this.data = this.source.entry;
    console.log(this.data);
  }

  addFavourite(a: any, b: any, i: string | number) {
    if (this.data[i].fav === false) {
      this.fav.push({ name: a, poster: b, fav: true });
      this.data[i].fav = true;
      console.log(this.data);
    }
  }
  removeFavourite(a, i: number) {
    this.fav[i].fav = false;

    this.fav.splice(i, 1);

    console.log(i, this.fav, this.data);
  }

  ngOnInit() {}
}
