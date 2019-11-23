import { Component, OnInit } from '@angular/core';
import { Product } from '../../product';
import { RouterService } from '../../services/router.service';
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  product: any;
  errMessage: any;

  constructor(private service: ProductService, private route: ActivatedRoute) {}

  ngOnInit() {
    console.log('details');

    this.route.paramMap.subscribe((params: ParamMap) => {
      const id = +params.get('id');
      console.log(id);

      this.service.getProdById(id).subscribe(res => (this.product = res));
      this.service.getProdById(id).subscribe(
        res => {
          if (res.status === 200) {
            this.product = res.body;
            console.log(this.product);
          }
        },
        error => {
          console.log(error);
        }
      );
    });
  }
  cart(prod) {
    this.service.addToCart(prod).subscribe(
      data => {},
      err => {
        this.errMessage = err.message;
      }
    );
  }
}
