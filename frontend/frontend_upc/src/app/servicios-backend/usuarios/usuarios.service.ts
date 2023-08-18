import { Injectable } from '@angular/core';
import{HttpClient, HttpResponse} from '@angular/common/http'
import { Observable, Observer } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UsuariosService {
PATH_BACKEND="http://localhost:5159/api/usuarios/"
GET_ALL= this.PATH_BACKEND+"GetAllUsuarios"
  constructor(private httpClient:HttpClient) { }

  public GetAllUsuarios():Observable<HttpResponse<any>>{
    return this.httpClient.get<any>(this.GET_ALL, {observe:'response'}).pipe();
  }
}
