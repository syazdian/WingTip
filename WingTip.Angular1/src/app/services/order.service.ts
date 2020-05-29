import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CartItem } from '../models/cart-item';
import { InsertProduct } from '../models/insert-product';
import { Register } from '../models/register';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  InsertOneProduct(insert: InsertProduct): Observable<any> {
    return this.http.post<any>('https://localhost:44345/order/product', insert, httpOptions).pipe();
  }

  RegisterOrder(register: Register): Observable<any> {
    return this.http.post<any>('https://localhost:44345/order/register', register, httpOptions).pipe();
  }

  public GetShoppingCart(cartId: string): Observable<CartItem[]> {
    return this.http.get<CartItem[]>('https://localhost:44345/order/' + cartId);
  }

}
