import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {ProductTableComponent} from '../shared/components/product-table/product-table.component';
import {MaterialModule} from '../shared/material/material.module';
import {SharedRoutingModule} from './shared-routing.module';

@NgModule({
    declarations: [
        ProductTableComponent,
    ],
    imports: [
        SharedRoutingModule,
        MaterialModule,
        CommonModule
    ],
    exports: [ProductTableComponent, MaterialModule]
})
export class SharedModule { }
