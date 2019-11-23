import { Movie } from './movie';
export class Model {
  entry: Movie[] = [];

  constructor() {
    this.entry.push({
        name: 'Avengers: Endgame',
        poster: 'https://image.tmdb.org/t/p/w500/or06FN3Dka5tukK1e9sl16pB3iy.jpg',
        fav: false
      });
    this.entry.push({
      name: 'Fast & Furious Presents: Hobbs & Shaw',
      poster: 'https://image.tmdb.org/t/p/w500/keym7MPn1icW1wWfzMnW3HeuzWU.jpg',
      fav: false
    });
    this.entry.push({
      name: 'The Lion King',
      poster: 'https://image.tmdb.org/t/p/w500/2bXbqYdUdNVa8VIWXVfclP2ICtT.jpg',
      fav: false
    });
    this.entry.push({
      name: 'Angel Has Fallen',
      poster: 'https://image.tmdb.org/t/p/w500/fapXd3v9qTcNBTm39ZC4KUVQDNf.jpg',
      fav: false
    });
    this.entry.push({
      name: 'Cars',
      poster: 'https://image.tmdb.org/t/p/w500/jpfkzbIXgKZqCZAkEkFH2VYF63s.jpg',
      fav: false
    });
    this.entry.push({
        name: 'The Old Man & the Gun',
        poster: 'https://image.tmdb.org/t/p/w500/a4BfxRK8dBgbQqbRxPs8kmLd8LG.jpg',
        fav: false
      });
  }
}
