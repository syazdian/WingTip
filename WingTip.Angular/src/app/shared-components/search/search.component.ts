import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  public searchForm: FormGroup;
  public sText: string;
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.searchForm = new FormGroup({
      searchText: new FormControl(null, [Validators.required, Validators.minLength(2)])
    });
  }
  onSubmit() {
    this.sText = this.searchForm.value.searchText;
    this.searchForm.reset();
    this.router.navigate(['/product/search/' + this.sText]);
  }

}
