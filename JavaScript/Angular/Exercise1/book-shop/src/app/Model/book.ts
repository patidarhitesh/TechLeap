export class Book {
  constructor(
    public id: number,
    public title: string,
    public author: string,
    public category: string,
    public quantityAvailable: number,
    public publishingDate: Date,
    public price: number,
    public cart: boolean
  ) {}
}
