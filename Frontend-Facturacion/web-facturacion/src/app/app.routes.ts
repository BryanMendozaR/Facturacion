import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

export const routes: Routes = [
    {
        path: 'facturacion',
        loadChildren: () => import('./features/features.module').then(m => m.FeaturesModule)
    },
    {
        path: '**',
        redirectTo: 'facturacion'
    }
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }