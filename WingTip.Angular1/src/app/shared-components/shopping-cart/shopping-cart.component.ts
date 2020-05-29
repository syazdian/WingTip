import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CartItem } from '../../models/cart-item';
import { OrderService } from '../../services/order.service';


@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})

export class ShoppingCartComponent implements OnInit {

  public cart: CartItem[];
  public cartId: string;
  constructor(private orderService: OrderService, private router: Router, ) { }

  ngOnInit(): void {

    this.cartId = localStorage.getItem('cartId');
    if (!this.cartId) {
      this.router.navigate(['/product']);
    }


    this.orderService.GetShoppingCart(this.cartId).subscribe(res => {
      if (res.length > 0) {
        this.cart = res;
      }
    });
  }

  public getTotal(): number {

    let total = 0;

    this.cart.forEach(element => {
      total += element.quantity * element.unitPrice;
    });

    return total;
  }


}
