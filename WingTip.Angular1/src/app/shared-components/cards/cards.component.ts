import { Component, Input, OnInit } from '@angular/core';
import { ProductDto } from '../../models/product';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {

  constructor() { }
  @Input() public product: ProductDto;

  ngOnInit(): void {
  }


}
