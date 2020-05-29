import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { map } from 'rxjs/operators';
import { switchMap } from 'rxjs/operators';
import { InsertProduct } from '../../models/insert-product';
import { ProductDto } from '../../models/product';
import { GetProductsService } from '../../services/get-products.service';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-single-product',
  templateUrl: './single-product.component.html',
  styleUrls: ['./single-product.component.css']
})
export class SingleProductComponent implements OnInit {

  public product: ProductDto = null;

  constructor(private prodService: GetProductsService, private route: ActivatedRoute, private orderService: OrderService, private router: Router) { }

  ngOnInit(): void {
    this.route.params.pipe(map((param: Params) => param.id)).pipe(switchMap((id) => {
      return this.prodService.GetSingleProduct(id);
    })).subscribe(res => {
      this.product = res;
    });
  }


  addToCart(productId: number) {
    let cartId = localStorage.getItem('cartId');
    if (!cartId) {
      cartId = Guid.create().toString();
      localStorage.setItem('cartId', cartId);
    }
    const productToInsert: InsertProduct = new InsertProduct(productId = productId, cartId = cartId);
    this.orderService.InsertOneProduct(productToInsert).subscribe(res => {
      console.log(res);
    }

    );

  }

  checkOut() {
    this.router.navigate(['/checkout']);
  }
}
