import { Component, OnInit } from '@angular/core';
import { Category } from '../../models/category';
import { CategoryService } from './../../services/category.service';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
})
export class CategoryComponent implements OnInit {

  public categoryList: Category[] = [];
  constructor(private categoryService: CategoryService) { }


  ngOnInit(): void {

    this.categoryService.getCurrentCategories().subscribe(categories => {

      if (categories === null) {
        this.categoryService.GetCategories().subscribe(res => {
          if (res.length > 0) {
            this.categoryService.setCurrentCategories(res);
          }
        });
      }
      else {
        this.categoryList = categories;
      }
    });

  }

}
