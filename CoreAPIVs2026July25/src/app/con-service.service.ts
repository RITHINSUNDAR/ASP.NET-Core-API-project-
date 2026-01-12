import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Usertab{
  UserId:number;
  Name:string;
  Age:number;
  Address:string;
  Email:string;
  Photo:string;
  Username:string;
  Password:string;
}


const apiUrl="http://localhost:5189/UserManagement/";
@Injectable({
  providedIn: 'root'
})
export class ConServiceService {

  constructor( private http: HttpClient) { }

  createUser(user: any, file: File): Observable<any> {
    const url =apiUrl + 'inserttab';

    const formData: FormData = new FormData();

    formData.append('Name', user.Name);
    formData.append('Age', user.Age.toString());
    formData.append('Address', user.Address);
    formData.append('Email', user.Email);
    formData.append('Username', user.Username);
    formData.append('Password', user.Password);
    if(file){
      formData.append('path', file);
    }
    return this.http.post(url, formData);
  }
  login(credentials: any): Observable<any> {
    return this.http.post(apiUrl + 'LoginTab', credentials);
  }
  getProfile(id: any): Observable<any> {
    return this.http.get<Usertab>(apiUrl + 'gettabWithId/' + id);
  }

  }
