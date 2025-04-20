import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {MaterialModule} from '../shared/material/material.module';
import {BarraComponent} from './components/barra/barra.component';
import {TableComponent} from './components/table/table.component';
import {SharedRoutingModule} from './shared-routing.module';

@NgModule({
    declarations: [
        TableComponent,
        BarraComponent
    ],
    imports: [
        SharedRoutingModule,
        MaterialModule,
        CommonModule,
        FormsModule
    ],
    exports: [TableComponent, BarraComponent, MaterialModule]
})
export class SharedModule { }
