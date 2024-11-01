import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiBaseUrl;

  getStudents(){
    var url = this.baseUrl + "/Students"
    return this.http.get(url);
  }

  createStudent(student:any){
    var url = this.baseUrl + "/Students/AddStudent"
    return this.http.post(url,student);
  }

}
