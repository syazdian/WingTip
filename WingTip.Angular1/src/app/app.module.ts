import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FirstPageComponent } from './pages/first-page/first-page.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { OrderComponent } from './pages/order/order.component';
import { SingleProductComponent } from './pages/single-product/single-product.component';
import { SummaryComponent } from './pages/summary/summary.component';
import { CategoryService } from './services/category.service';
import { CardsComponent } from './shared-components/cards/cards.component';
import { CategoryComponent } from './shared-components/category/category.component';
import { SearchComponent } from './shared-components/search/search.component';
import { SiteFooterComponent } from './shared-components/site-footer/site-footer.component';
import { SiteHeaderComponent } from './shared-components/site-header/site-header.component';
import { ShoppingCartComponent } from './shared-components/shopping-cart/shopping-cart.component';
@NgModule({
  declarations: [
    AppComponent,
    SiteHeaderComponent,
    NotFoundComponent,
    FirstPageComponent,
    SingleProductComponent,
    OrderComponent,
    SummaryComponent,
    CardsComponent,
    CategoryComponent,
    SearchComponent,
    SiteFooterComponent,
    ShoppingCartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    SweetAlert2Module.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
