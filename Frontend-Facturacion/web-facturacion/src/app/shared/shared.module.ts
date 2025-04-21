import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MaterialModule} from '../shared/material/material.module';
import {BarraComponent} from './components/barra/barra.component';
import {ModalConfirmacionComponent} from './components/modal-confirmacion/modal-confirmacion.component';
import {ModalComponent} from './components/modal/modal.component';
import {TableComponent} from './components/table/table.component';
import {SharedRoutingModule} from './shared-routing.module';

@NgModule({
    declarations: [
        TableComponent,
        BarraComponent,
        ModalComponent,
        ModalConfirmacionComponent
    ],
    imports: [
        SharedRoutingModule,
        MaterialModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ],
    exports: [TableComponent, ModalComponent, BarraComponent, ModalConfirmacionComponent, MaterialModule]
})
export class SharedModule { }
