import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IUsuario } from 'src/app/interfaces/IUsuario';
import { UsuariosService } from 'src/app/services/Usuarios.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.scss'],
})
export class UsuariosComponent {
  constructor(
    private fb: FormBuilder,
    private services: UsuariosService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}
  ngOnInit(): void {
    this.getUsuarios();
    this.validateForm = this.fb.group({
      nombre: [null, [Validators.required]],
      direccion: [null, [Validators.required]],
      telefono: [null, [Validators.required]],
      email: [null, [Validators.required,Validators.email]],
    });
  }
  displayedColumns: string[] = [
    'nombre',
    'direccion',
    'email',
    'telefono',
    'options',
  ];
  buscador:string="";
  validateForm!: FormGroup;
  listData: IUsuario[] = [];
  currentItem: IUsuario = {};
  currentItemIndex: number = 0;
  addDialogRef!: MatDialogRef<TemplateRef<any>>;
  @ViewChild('addDialog') addDialog: TemplateRef<any> | undefined;
  async getUsuarios() {
    try {
      const res = await this.services.getUsuarios();
      this.listData = res!;
    } catch (error) {}
  }
  async openDialogSave(
    option: boolean,
    item: IUsuario = {},
    index: number = -1
  ) {
    this.setCurrentItem(item, index);
    if (option) {
      this.addDialogRef = this.dialog.open(this.addDialog!, {
        disableClose: true,
      });
    } else {
      this.addDialogRef.close();
    }

    this.validateForm.reset();
  }
  async openDelete(item: IUsuario, index: number) {
    this.setCurrentItem(item, index);
    try {
      await this.services.deleteUsuario(this.currentItem);
      this.snackBar.open('Se elimino al usuario', undefined, {
        duration: 2000,
      });
      this.listData = [
        ...this.listData.filter((value, i, array) => i != index),
      ];
    } catch (error: any) {
      this.snackBar.open(error.error, undefined, {
        duration: 2000,
      });
    }
  }
  async saveDialog() {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].markAsTouched();

      this.validateForm.controls[i].updateValueAndValidity();
    }

    if (this.validateForm.valid) {
      try {
        let res: IUsuario | undefined;

        if (this.currentItem.id == undefined) {
          this.currentItem.telefono = this.currentItem.telefono + '';
          res = await this.services.addUsuario(this.currentItem);
          this.listData.unshift(res!);
        } else {
          res = await this.services.updateUsuario(this.currentItem);
          this.listData[this.currentItemIndex] = res!;
        }
        this.listData = [...this.listData];
        this.snackBar.open('Tarea completa', undefined, {
          duration: 2000,
        });
        this.openDialogSave(false);
      } catch (error: any) {
        this.snackBar.open(error.error, undefined, {
          duration: 2000,
        });
      }
    }
  }
  async search(){
    if(this.buscador==""){
      this.getUsuarios()
    }
    else{
     try {
      const res = await this.services.searchUsuarios(this.buscador);
      this.listData = res!;
     } catch (error) {
      
     }  
      
    }
  }
  setCurrentItem(item: IUsuario, index: number) {
    this.currentItem = Object.assign({}, item);
    this.currentItemIndex = index;
  }
}
