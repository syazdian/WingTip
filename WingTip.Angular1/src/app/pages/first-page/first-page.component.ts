import { Component, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Category } from '../../models/category';
import { ProductDto } from '../../models/product';
import { GetProductsService } from '../../services/get-products.service';

import { map } from 'rxjs/operators';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-first-page',
  templateUrl: './first-page.component.html',
  styleUrls: ['./first-page.component.css']
})
export class FirstPageComponent implements OnInit {

  constructor(private getProducts: GetProductsService, private router: Router, private route: ActivatedRoute) { }

  public prodList: ProductDto[] = [];
  public href = '';
  public search = '';
  public isFirstPage = false;

  public titlepage = 'Products';

  ngOnInit(): void {
    this.href = this.router.url.toLowerCase();

    if (this.href.includes('search')) {
      this.route.params.pipe(map((param: Params) => param.q)).pipe(switchMap((q: string) => {
        this.search = q;
        return this.getProducts.GetProductBySearch(q);
      })).subscribe(res => {
        this.prodList = res;
        this.titlepage = 'Search results for: ' + this.search;
        this.isFirstPage = false;
      });
    }
    else if (this.href.includes('category')) {
      this.route.params.pipe(map((param: Params) => param.id)).pipe(switchMap((id: number) => {
        return this.getProducts.GetProductByCategory(id);
      })).subscribe(res => {
        this.prodList = res;
        this.titlepage = 'Products in ' + this.prodList[0].category + ' Category';
        this.isFirstPage = false;
      });
    }
    else {
      this.getProducts.GetProducts().subscribe(res => {
        if (res.length > 0) {
          this.prodList = res;
          this.titlepage = 'Products';
          this.isFirstPage = true;
        }
      });
    }

  }
}
