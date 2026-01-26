import { Container } from "inversify";
import { TYPES } from "./Types";
import { IPersonaRepository } from "../Domain/Repositories/IPersonaRepository";
import { IDepartamentoRepository } from "../Domain/Repositories/IDepartamentoRepository";
import { IPersonaUseCase } from "../Domain/Interfaces/IPersonaUseCase";
import { IDepartamentoUseCase } from "../Domain/Interfaces/IDepartamentoUseCase";
import { PersonaRepository } from "../Data/Repositories/PersonaRepository";
import { DepartamentoRepository } from "../Data/Repositories/DepartamentoRepository";
import { PersonaUseCase } from "../Domain/UseCases/PersonaUseCase";
import { DepartamentoUseCase } from "../Domain/UseCases/DepartamentoUseCase";

const container = new Container();

container.bind<IPersonaRepository>(TYPES.IPersonaRepository).to(PersonaRepository);
container.bind<IDepartamentoRepository>(TYPES.IDepartamentoRepository).to(DepartamentoRepository);
container.bind<IPersonaUseCase>(TYPES.IPersonaUseCase).to(PersonaUseCase);
container.bind<IDepartamentoUseCase>(TYPES.IDepartamentoUseCase).to(DepartamentoUseCase);

export { container };