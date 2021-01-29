import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl= "http://localhost:49327/api";
  constructor(private http:HttpClient) {}

  getPropList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Properties/GetAll');
  }

  getProp(val:any):Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Properties/get/' + val);
  }

  addProperty(val:any){
    return this.http.post(this.APIUrl+'/Properties/Post',val);
  }

  updateProperty(val:any){
    return this.http.put(this.APIUrl+'/Properties/Update',val);
  }

  deleteProperty(val:any){
    console.log(val);
    return this.http.delete(this.APIUrl+'/Properties/Delete/'+val);
  }
}
