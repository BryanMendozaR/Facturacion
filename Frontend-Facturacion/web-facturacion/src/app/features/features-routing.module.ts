import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {GestionClienteComponent} from './cliente/pages/gestion-cliente/gestion-cliente.component';
import {GestionProductoComponent} from './producto/pages/gestion-producto/gestion-producto.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {path: 'producto', component: GestionProductoComponent},
      {path: 'cliente', component: GestionClienteComponent},
      {path: '**', redirectTo: 'producto'},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeaturesRoutingModule { }
