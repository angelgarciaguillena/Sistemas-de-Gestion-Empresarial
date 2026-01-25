import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { DepartamentosViewModel } from '../../ViewModels/DepartamentosViewModel';
import { Departamento } from '../../../Domain/Entities/Departamento';
import { DepartamentoListItemComponent } from '../departamento-list-item/departamento-list-item';

@Component({
  selector: 'app-listado-departamentos',
  standalone: true,
  imports: [CommonModule, DepartamentoListItemComponent],
  templateUrl: './listado-departamentos.html',
  styleUrls: ['./listado-departamentos.css']
})
export class ListadoDepartamentosComponent implements OnInit {

  constructor(
    private viewModel: DepartamentosViewModel,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.viewModel.cargarDepartamentos();
  }

  nuevoDepartamento(): void {
    this.router.navigate(['/departamentos/nuevo']);
  }

  editarDepartamento(departamento: Departamento): void {
    this.router.navigate(['/departamentos/editar', departamento.id]);
  }

  async eliminarDepartamento(id: number): Promise<void> {
    await this.viewModel.eliminarDepartamento(id);
  }
}