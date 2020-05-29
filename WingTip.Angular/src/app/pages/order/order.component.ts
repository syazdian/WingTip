import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Register } from '../../models/register';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  public registerForm: FormGroup;
  constructor(private orderService: OrderService, private router: Router, ) { }
  cartId = '';
  ngOnInit(): void {

    this.cartId = localStorage.getItem('cartId');
    if (!this.cartId) {
      this.router.navigate(['/product']);
    }


    this.registerForm = new FormGroup({
      username: new FormControl(null, Validators.required),
      firstName: new FormControl(null, Validators.required),
      lastName: new FormControl(null, Validators.required),
      address: new FormControl(null, Validators.required),
      city: new FormControl(null, Validators.required),
      state: new FormControl(null, Validators.required),
      postalCode: new FormControl(null, Validators.required),
      phone: new FormControl(null, [Validators.required,]),
      email: new FormControl(null, [Validators.email, Validators.required]),
      country: new FormControl(null, Validators.required),

    });
  }




  onSubmit() {
    const registerOrder = new Register(
      this.cartId,
      this.registerForm.value.username,
      this.registerForm.value.firstName,
      this.registerForm.value.lastName,
      this.registerForm.value.address,
      this.registerForm.value.city,
      this.registerForm.value.state,
      this.registerForm.value.postalCode,
      this.registerForm.value.phone,
      this.registerForm.value.email,
      this.registerForm.value.country
    );

    this.orderService.RegisterOrder(registerOrder).subscribe();
    localStorage.removeItem('cartId');

    setTimeout(() => { this.router.navigate(['/product']); }, 1000);
  }

}




