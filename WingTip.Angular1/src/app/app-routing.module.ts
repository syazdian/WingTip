import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FirstPageComponent } from './pages/first-page/first-page.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { OrderComponent } from './pages/order/order.component';
import { SingleProductComponent } from './pages/single-product/single-product.component';
import { SummaryComponent } from './pages/summary/summary.component';


const routes: Routes = [
  { path: '', redirectTo: 'product', pathMatch: 'full', },
  { path: 'product', component: FirstPageComponent, },
  { path: 'product/search/:q', component: FirstPageComponent, },
  { path: 'product/:id', component: SingleProductComponent, },
  { path: 'product/category/:id', component: FirstPageComponent },
  { path: 'checkout', component: OrderComponent },
  { path: 'summary', component: SummaryComponent },
  { path: '**', component: NotFoundComponent, },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
