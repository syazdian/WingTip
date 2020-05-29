import { HttpClient } from '@angular/common/http';
import { Injectable, NgModule } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Category } from './../models/Category';


@Injectable({
  providedIn: 'root'
})


export class CategoryService {
  private categories: BehaviorSubject<Category[]> = new BehaviorSubject<Category[]>(null);
  constructor(private http: HttpClient) { }

  public GetCategories(): Observable<Category[]> {
    return this.http.get<Category[]>('https://localhost:44345/product/category');
  }

  public getCurrentCategories(): Observable<Category[]> {
    return this.categories;
  }

  public setCurrentCategories(categoryList: Category[]) {
    this.categories.next(categoryList);
  }


}
