import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiBaseUrl;

  getStudents() {
    var url = this.baseUrl + "/Students"
    return this.http.get(url);
  }

  createStudent(student: any) {
    var url = this.baseUrl + "/Students/AddStudent"
    return this.http.post(url, student);
  }

  deleteStudent(id: number) {
    var url = this.baseUrl + "/Students/Delete/" + id;
    return this.http.delete(url);
  }

  getStudent(id: number) {
    var url = this.baseUrl + "/Students/" + id;
    return this.http.get(url);
  }

  updateStudent(student: any) {
    var url = this.baseUrl + "/Students/Update/"+student.id
    return this.http.put(url, student);
  }

  formatDate(dateString: string){
    const inputDate = new Date(dateString);
    const year = inputDate.getFullYear();
    console.log("year",year);
    const month = String(inputDate.getMonth() + 1).padStart(2, '0');
    console.log("month",month);
    const day = String(inputDate.getDate()).padStart(2, '0');
    console.log("day",day);
    return `${year}-${month}-${day}`;
  }


}
