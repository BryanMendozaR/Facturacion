import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';
import {InicioSesionComponent} from './auth/inicio-sesion/inicio-sesion.component';
import {GestionClienteComponent} from './cliente/pages/gestion-cliente/gestion-cliente.component';
import {FeaturesRoutingModule} from './features-routing.module';
import {BarraSuperiorComponent} from './menu/barra-superior/barra-superior.component';
import {PaginaMaestraComponent} from './menu/pagina-maestra/pagina-maestra.component';
import {GestionProductoComponent} from './producto/pages/gestion-producto/gestion-producto.component';

@NgModule({
  declarations:
    [
      GestionProductoComponent,
      GestionClienteComponent,
      InicioSesionComponent,
      PaginaMaestraComponent,
      BarraSuperiorComponent
    ],
  imports: [
    CommonModule,
    FeaturesRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class FeaturesModule { }
