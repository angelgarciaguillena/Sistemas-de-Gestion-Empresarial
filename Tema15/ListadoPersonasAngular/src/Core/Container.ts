import { Container } from "inversify";
import { TYPES } from "./Types.js";
import { IPersonaRepository } from "../Domain/Repositories/IPersonaRepository.js";
import { IDepartamentoRepository } from "../Domain/Repositories/IDepartamentoRepository.js";
import { IPersonaUseCase } from "../Domain/Interfaces/IPersonaUseCase.js";
import { IDepartamentoUseCase } from "../Domain/Interfaces/IDepartamentoUseCase.js";
import { PersonaRepository } from "../Data/Repositories/PersonaRepository.js";
import { DepartamentoRepository } from "../Data/Repositories/DepartamentoRepository.js";
import { PersonaUseCase } from "../Domain/UseCases/PersonaUseCase.js";
import { DepartamentoUseCase } from "../Domain/UseCases/DepartamentoUseCase.js";

const container = new Container();

container.bind<IPersonaRepository>(TYPES.IPersonaRepository).to(PersonaRepository);
container.bind<IDepartamentoRepository>(TYPES.IDepartamentoRepository).to(DepartamentoRepository);
container.bind<IPersonaUseCase>(TYPES.IPersonaUseCase).to(PersonaUseCase);
container.bind<IDepartamentoUseCase>(TYPES.IDepartamentoUseCase).to(DepartamentoUseCase);

export { container };