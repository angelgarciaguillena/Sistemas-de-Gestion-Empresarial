import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonasViewModel } from '../../ViewModels/PersonasViewModel';
import { DepartamentosViewModel } from '../../ViewModels/DepartamentosViewModel';
import { PersonaDTO } from '../../../Domain/DTOs/PersonaDTO';

@Component({
  selector: 'app-editar-insertar-persona',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './editar-insertar-persona.html',
  styleUrls: ['./editar-insertar-persona.css']
})
export class EditarInsertarPersonaComponent implements OnInit {
  personaForm: FormGroup;
  esEdicion = false;
  personaId?: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private viewModel: PersonasViewModel,
    private departamentosViewModel: DepartamentosViewModel
  ) {
    this.personaForm = this.fb.group({
      nombre: ['', Validators.required],
      apellidos: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      direccion: ['', Validators.required],
      telefono: ['', Validators.required],
      foto: [''],
      idDepartamento: ['', Validators.required]
    });
  }

  async ngOnInit(): Promise<void> {
    await this.departamentosViewModel.cargarDepartamentos();
    
    this.personaId = Number(this.route.snapshot.paramMap.get('id'));
    
    if (this.personaId) {
      this.esEdicion = true;
      await this.viewModel.seleccionarPersona(this.personaId);
      
      this.viewModel.personaSeleccionada$.subscribe(persona => {
        if (persona) {
          const fechaFormato = persona.fechaNacimiento.toISOString().split('T')[0];
          this.personaForm.patchValue({
            nombre: persona.nombre,
            apellidos: persona.apellidos,
            fechaNacimiento: fechaFormato,
            direccion: persona.direccion,
            telefono: persona.telefono,
            foto: persona.foto,
            idDepartamento: persona.idDepartamento
          });
        }
      });
    }
  }

  async guardar(): Promise<void> {
    if (this.personaForm.valid) {
      const formValue = this.personaForm.value;
      
      // Obtener el nombre del departamento seleccionado
      let nombreDepartamento = '';
      this.departamentosViewModel.departamentos$.subscribe(departamentos => {
        const dpto = departamentos.find(d => d.id === Number(formValue.idDepartamento));
        nombreDepartamento = dpto?.nombre || '';
      });

      const persona = new PersonaDTO(
        this.personaId || 0,
        formValue.nombre,
        formValue.apellidos,
        new Date(formValue.fechaNacimiento),
        formValue.direccion,
        formValue.telefono,
        formValue.foto || '',
        Number(formValue.idDepartamento),
        nombreDepartamento
      );

      if (this.esEdicion && this.personaId) {
        await this.viewModel.actualizarPersona(persona);
      } else {
        await this.viewModel.crearPersona(persona);
      }

      this.router.navigate(['/personas']);
    }
  }

  cancelar(): void {
    this.router.navigate(['/personas']);
  }
}
