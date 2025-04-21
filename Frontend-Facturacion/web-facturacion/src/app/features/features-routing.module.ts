import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {InicioSesionComponent} from './auth/inicio-sesion/inicio-sesion.component';
import {GestionClienteComponent} from './cliente/gestion-cliente/gestion-cliente.component';
import {PaginaMaestraComponent} from './menu/pagina-maestra/pagina-maestra.component';
import {GestionProductoComponent} from './producto/gestion-producto/gestion-producto.component';

const routes: Routes = [
  {path: 'login', component: InicioSesionComponent},
  {
    path: 'inicio',
    component: PaginaMaestraComponent,
    children: [
      {
        path: 'producto',
        component: GestionProductoComponent,
      },
      {
        path: 'cliente',
        component: GestionClienteComponent,
      },
    ]
  },
  {path: '**', redirectTo: 'login'},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeaturesRoutingModule { }
