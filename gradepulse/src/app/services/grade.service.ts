import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GradeService {

  private http = inject(HttpClient);
  private baseUrl = environment.apiBaseUrl;

  getGrades() {
    var url = this.baseUrl + "/Grades"
    return this.http.get(url);
  }

  createGrade(grade: any) {
    var url = this.baseUrl + "/Grades/AddGrade"
    return this.http.post(url, grade);
  }

  GetGradesGroupByStudent() {
    var url = this.baseUrl + "/Grades/Crosstab"
    return this.http.get(url);
  }

  deleteGrade(gradeDelete: any) {
    var url = this.baseUrl + "/Grades/Delete"

    return this.http.delete(url,{
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      body:gradeDelete
    });      
    
  }

  updateGrade(gradeUpdate: any) {
    var url = this.baseUrl + "/Grades/Update"
    return this.http.put(url, gradeUpdate);  
  }
}
