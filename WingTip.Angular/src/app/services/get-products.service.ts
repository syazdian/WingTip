import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDto } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class GetProductsService {


  constructor(private http: HttpClient) { }

  public GetProducts(): Observable<ProductDto[]> {
    return this.http.get<ProductDto[]>('https://localhost:44345/product');
  }

  public GetSingleProduct(id: number): Observable<ProductDto> {
    return this.http.get<ProductDto>('https://localhost:44345/product/' + id);
  }

  public GetProductByCategory(id: number): Observable<ProductDto[]> {
    return this.http.get<ProductDto[]>('https://localhost:44345/product/getbycategory/' + id);
  }

  public GetProductBySearch(q): Observable<ProductDto[]> {
    return this.http.get<ProductDto[]>('https://localhost:44345/product/search/' + q);
  }




}


