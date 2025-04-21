import {Injectable} from '@angular/core';
import {FormGroup, ValidationErrors} from '@angular/forms';

@Injectable({providedIn: 'root'})

export class ValidatorsService {

    public validacionCamposIguales(campo1: string, campo2: string) {

        return (formGroup: FormGroup): ValidationErrors | null => {
            const campoPrincipal = formGroup.get(campo1)?.value || '';
            const campoSecundario = formGroup.get(campo2)?.value || '';

            if (campoPrincipal !== campoSecundario) {
                formGroup.get(campo2)?.setErrors({notEqual: true});
                return {notEqual: true}
            }
            formGroup.get(campo2)?.setErrors(null);
            return null;
        }

    }

}