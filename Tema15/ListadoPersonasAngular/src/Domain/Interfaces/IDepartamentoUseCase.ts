import { Departamento } from '../Entities/Departamento';

export interface IDepartamentoUseCase {
  getDepartamentos(): Promise<Departamento[]>;
  getDepartamento(id: number): Promise<Departamento>;
  agregarDepartamento(departamento: Departamento): Promise<number>;
  actualizarDepartamento(departamento: Departamento): Promise<number>;
  eliminarDepartamento(id: number): Promise<number>;
}