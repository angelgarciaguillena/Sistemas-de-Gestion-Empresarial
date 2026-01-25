import { Routes } from '@angular/router';
import { WelcomeScreenComponent } from '../UI/Components/welcome-screen/welcome-screen';
import { ListadoPersonasComponent } from '../UI/Components/listado-personas/listado-personas';
import { EditarInsertarPersonaComponent } from '../UI/Components/editar-insertar-persona/editar-insertar-persona';
import { ListadoDepartamentosComponent } from '../UI/Components/listado-departamentos/listado-departamentos';
import { EditarInsertarDepartamentoComponent } from '../UI/Components/editar-insertar-departamento/editar-insertar-departamento';

export const routes: Routes = [
  { path: '', component: WelcomeScreenComponent },
  { path: 'personas', component: ListadoPersonasComponent },
  { path: 'personas/nuevo', component: EditarInsertarPersonaComponent },
  { path: 'personas/editar/:id', component: EditarInsertarPersonaComponent },
  { path: 'departamentos', component: ListadoDepartamentosComponent },
  { path: 'departamentos/nuevo', component: EditarInsertarDepartamentoComponent },
  { path: 'departamentos/editar/:id', component: EditarInsertarDepartamentoComponent },
  { path: '**', redirectTo: '' }
];