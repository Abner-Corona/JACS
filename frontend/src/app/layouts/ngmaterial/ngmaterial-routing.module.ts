import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NgmaterialComponent } from './ngmaterial.component';

const routes: Routes = [
  { path: '', component: NgmaterialComponent, children: [
    {
      path: 'usuarios',
      loadChildren: () =>
        import('./pages/usuarios/usuarios.module').then((m) => m.UsuariosModule),
    },
  ] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NgmaterialRoutingModule {}
