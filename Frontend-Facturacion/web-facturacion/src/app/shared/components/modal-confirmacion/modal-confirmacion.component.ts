import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-modal-confirmacion',
  templateUrl: './modal-confirmacion.component.html',
  styleUrl: './modal-confirmacion.component.scss'
})
export class ModalConfirmacionComponent {
  @Input() titulo: string = '';
  @Input() isVisible: boolean = false;
  @Input() tamano: 'small' | 'medium' | 'large' = 'medium';
  @Output() cerrarModal = new EventEmitter<void>();
  @Output() confirmarModal = new EventEmitter<void>();

  cerrar() {
    this.cerrarModal.emit();
  }

  confirmar() {
    this.confirmarModal.emit();
  }
}
