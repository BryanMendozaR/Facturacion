import {Component, EventEmitter, Inject, Output} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.scss'
})
export class ModalComponent {
  form!: FormGroup;
  @Output() onGuardar = new EventEmitter<any>();

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<ModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  /*
  * Metodo que se ejecuta despues de inicializar la vista
  * se inicializa el formulario
  */
  ngOnInit(): void {
    const group: any = {};
    this.data.campos.forEach((campo: any) => {
      group[campo.nombre] =
        [
          campo.valor,
          campo.validaciones || []
        ];
    });

    this.form = this.fb.group(group);
  }

  /*
  * Metodo para enviar la informacion del formulario
  */
  guardar() {

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.onGuardar.emit(this.form.value);

  }

  /*
  * Metodo para cerrar el formulario
  */
  cerrar() {
    this.dialogRef.close();
  }
}
