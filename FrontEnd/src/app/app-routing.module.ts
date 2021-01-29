import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {PropertyComponent} from './property/property.component';

const routes: Routes = [
  {path:'property', component:PropertyComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
