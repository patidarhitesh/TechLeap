import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Product } from '../../product';
import { ProductService } from '../../services/product.service';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Product-list',
  templateUrl: './Product-list.component.html',
  styleUrls: ['./Product-list.component.css']
})
export class ProductListComponent implements OnInit {
  errMessage: string;
  product: Product = new Product();
  products: Array<Product>;

  constructor(private productService: ProductService, private router: Router) {}
  ngOnInit() {
    this.productService.getProducts().subscribe(
      result => (this.products = result),
      err => {
        this.errMessage = err.error.message;
      }
    );
    console.log(this.products);
  }
}
