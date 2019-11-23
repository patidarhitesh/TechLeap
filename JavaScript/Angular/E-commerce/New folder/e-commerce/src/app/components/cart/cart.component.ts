import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  products: any = [];
  check: any = [];
  total: number;
  errMessage: any;

  constructor(private service: ProductService) {
    // console.log(service.getCart());
  }
  removeproduct(product) {
    console.log('remove');
    this.service.removeCart(product);
    this.products.splice(product, 1);
  }
  ngDoCheck(): void {
    this.total = 0;
    this.products.forEach(element => {
      this.total = this.total + element.price;
    });
  }
  checkout() {
    this.service.checkout();
    this.products = [];
  }

  ngOnInit() {
    this.service.getCart().subscribe(
      result => (this.products = result),
      err => {
        this.errMessage = err.error.message;
      }
    );
    this.service.getCheckout().subscribe(
      result => (this.check = result),
      err => {
        this.errMessage = err.error.message;
      }
    );
    this.check = [...this.check]
    
  }
}
