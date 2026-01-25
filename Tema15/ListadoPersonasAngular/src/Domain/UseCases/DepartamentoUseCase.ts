import { inject, injectable } from 'inversify';
import { IDepartamentoUseCase } from '../Interfaces/IDepartamentoUseCase';
import { IDepartamentoRepository } from '../Repositories/IDepartamentoRepository';
import { Departamento } from '../Entities/Departamento';
import { TYPES } from '../../Core/Types';

@injectable()
export class DepartamentoUseCase implements IDepartamentoUseCase {
  constructor(
    @inject(TYPES.IDepartamentoRepository) private departamentoRepository: IDepartamentoRepository
  ) {}

  async getDepartamentos(): Promise<Departamento[]> {
    return await this.departamentoRepository.getDepartamentos();
  }

  async getDepartamento(id: number): Promise<Departamento> {
    return await this.departamentoRepository.getDepartamento(id);
  }

  async agregarDepartamento(departamento: Departamento): Promise<number> {
    return await this.departamentoRepository.agregarDepartamento(departamento);
  }

  async actualizarDepartamento(departamento: Departamento): Promise<number> {
    return await this.departamentoRepository.actualizarDepartamento(departamento);
  }

  async eliminarDepartamento(id: number): Promise<number> {
    return await this.departamentoRepository.eliminarDepartamento(id);
  }
}