import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgmaterialRoutingModule } from './ngmaterial-routing.module';
import { NgmaterialComponent } from './ngmaterial.component';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { UsuariosComponent } from './pages/usuarios/usuarios.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSliderModule } from '@angular/material/slider';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
@NgModule({
  declarations: [NgmaterialComponent, UsuariosComponent],
  imports: [
    CommonModule,
    NgmaterialRoutingModule,
    FormsModule,
    MatDialogModule,
    MatSliderModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatButtonModule,
    MatTableModule,
    MatIconModule,
    MatCheckboxModule,
    MatIconModule,
    MatSnackBarModule,
    MatSidenavModule,
    MatButtonModule,
    MatNativeDateModule,
    MatIconModule,
    MatListModule,
    MatFormFieldModule,
    MatDatepickerModule,
  ],
})
export class NgmaterialModule {}
