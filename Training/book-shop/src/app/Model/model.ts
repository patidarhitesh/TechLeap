import { Book } from './book';
export class Model {
  entry: Book[] = [];

  constructor() {
    this.entry.push({
      author: 'Chinua Achebe',
      category: 'Conspiracy',
      quantityAvailable: 50,
      id: 0,
      price: 209,
      title: 'Things Fall Apart',
      publishingDate: new Date(1 - 1 - 1836),
      cart: false
    });
    this.entry.push({
      author: 'Hans Christian Andersen',
      category: 'Conspiracy',
      quantityAvailable: 50,
      id: 1,
      price: 784,
      title: 'Fairy tales',
      publishingDate: new Date(1 - 1 - 1836),
      cart: false
    });
    this.entry.push({
      author: 'Dante Alighieri',
      category: 'Conspiracy',
      quantityAvailable: 50,
      id: 2,
      price: 928,
      title: 'The Divine Comedy',
      publishingDate: new Date(1 - 1 - 1315),
      cart: false
    });

    this.entry.push({
      author: 'Unknown',
      category: 'Conspiracy',
      quantityAvailable: 50,
      id: 3,
      price: 176,
      title: 'The Book Of Job',
      publishingDate: new Date(1 - 1 - 1600),
      cart: false
    });
    this.entry.push({
      author: 'Unknown',
      category: 'Conspiracy',
      quantityAvailable: 50,
      id: 4,
      price: 288,
      title: 'One Thousand Nights',
      publishingDate: new Date(1 - 1 - 1200),
      cart: false
    });
    this.entry.push({
      author: 'Unknown',
      category: 'Conspiracy',
      quantityAvailable: 50,
      id: 5,
      price: 384,
      title: 'Nj\u00e1l',
      publishingDate: new Date(1 - 1 - 1350),
      cart: false
    });
    this.entry.push({
      author: '01e Austen',
      category: 'Conspiracy',
      quantityAvailable: 50,
      id: 6,
      price: 226,
      title: 'Pride and Prejudice',
      publishingDate: new Date(1 - 1 - 1813),
      cart: false
    });
    this.entry.push({
      author: 'Honor\u00e9 de Balzac',
      category: 'Conspiracy',
      quantityAvailable: 50,
      id: 7,
      price: 443,
      title: 'Le P\u00e8re Goriot',
      publishingDate: new Date(1 - 1 - 1835),
      cart: false
    });
    this.entry.push({
      author: 'Samuel Beckett',
      category: 'Conspiracy',
      quantityAvailable: 50,
      id: 8,
      price: 256,
      title: 'Molloy, Malone Dies',
      publishingDate: new Date(1 - 1 - 1952),
      cart: false
    });
  }
}
