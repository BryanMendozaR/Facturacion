import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {SharedModule} from '../shared/shared.module';
import {GestionClienteComponent} from './cliente/pages/gestion-cliente/gestion-cliente.component';
import {FeaturesRoutingModule} from './features-routing.module';
import {GestionProductoComponent} from './producto/pages/gestion-producto/gestion-producto.component';


@NgModule({
  declarations:
    [
      GestionProductoComponent,
      GestionClienteComponent
    ],
  imports: [
    CommonModule,
    FeaturesRoutingModule,
    SharedModule,
  ]
})
export class FeaturesModule { }
