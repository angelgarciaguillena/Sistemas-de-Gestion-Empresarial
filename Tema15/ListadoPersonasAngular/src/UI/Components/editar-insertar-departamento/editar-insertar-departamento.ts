import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DepartamentosViewModel } from '../../ViewModels/DepartamentosViewModel';
import { Departamento } from '../../../Domain/Entities/Departamento';

@Component({
  selector: 'app-editar-insertar-departamento',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './editar-insertar-departamento.html',
  styleUrls: ['./editar-insertar-departamento.css']
})
export class EditarInsertarDepartamentoComponent implements OnInit {
  departamentoForm: FormGroup;
  esEdicion = false;
  departamentoId?: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private viewModel: DepartamentosViewModel
  ) {
    this.departamentoForm = this.fb.group({
      nombre: ['', Validators.required]
    });
  }

  async ngOnInit(): Promise<void> {
    this.departamentoId = Number(this.route.snapshot.paramMap.get('id'));
    
    if (this.departamentoId) {
      this.esEdicion = true;
      await this.viewModel.seleccionarDepartamento(this.departamentoId);
      
      this.viewModel.departamentoSeleccionado$.subscribe(departamento => {
        if (departamento) {
          this.departamentoForm.patchValue({
            nombre: departamento.nombre
          });
        }
      });
    }
  }

  async guardar(): Promise<void> {
    if (this.departamentoForm.valid) {
      const formValue = this.departamentoForm.value;
      const departamento = new Departamento(
        this.departamentoId || 0,
        formValue.nombre
      );

      if (this.esEdicion && this.departamentoId) {
        await this.viewModel.actualizarDepartamento(departamento);
      } else {
        await this.viewModel.crearDepartamento(departamento);
      }

      this.router.navigate(['/departamentos']);
    }
  }

  cancelar(): void {
    this.router.navigate(['/departamentos']);
  }
}