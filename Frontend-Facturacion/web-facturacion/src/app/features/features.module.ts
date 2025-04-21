import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';
import {InicioSesionComponent} from './auth/inicio-sesion/inicio-sesion.component';
import {GestionClienteComponent} from './cliente/gestion-cliente/gestion-cliente.component';
import {FeaturesRoutingModule} from './features-routing.module';
import {BarraSuperiorComponent} from './menu/barra-superior/barra-superior.component';
import {PaginaMaestraComponent} from './menu/pagina-maestra/pagina-maestra.component';
import {PanelInicialComponent} from './panel-inicial/panel-inicial.component';
import {GestionProductoComponent} from './producto/gestion-producto/gestion-producto.component';
import {GestionUsuarioComponent} from './usuario/gestion-usuario/gestion-usuario.component';

@NgModule({
  declarations:
    [
      GestionProductoComponent,
      GestionClienteComponent,
      GestionUsuarioComponent,
      InicioSesionComponent,
      PaginaMaestraComponent,
      PanelInicialComponent,
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
