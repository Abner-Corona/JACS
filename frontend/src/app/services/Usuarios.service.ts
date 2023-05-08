import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUsuario } from '../interfaces/IUsuario';

@Injectable({
  providedIn: 'root',
})
export class UsuariosService {
  constructor(private http: HttpClient) {}

  async getUsuarios() {
    return await this.http.get<IUsuario[]>('Usuario/GetAll').toPromise();
  }
  async deleteUsuario(item: IUsuario) {
    return await this.http.put<IUsuario>(`Usuario/Delete`, item).toPromise();
  }
  async addUsuario(item: IUsuario) {
    return await this.http.post<IUsuario>(`Usuario/Add`, item).toPromise();
  }

  async updateUsuario(item: IUsuario) {
    return await this.http.put<IUsuario>(`Usuario/Update`, item).toPromise();
  }
  async searchUsuarios(buscador:string){
    return await this.http.get<IUsuario[]>('Usuario/search/'+buscador).toPromise();
  }
}
