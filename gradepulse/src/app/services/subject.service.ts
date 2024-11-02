import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  private http = inject(HttpClient);
  private baseUrl = environment.apiBaseUrl;

  getSubjects() {
    var url = this.baseUrl + "/Subjects"
    return this.http.get(url);
  }

  createSubject(subject: any) {
    var url = this.baseUrl + "/Subjects/AddSubject"
    return this.http.post(url, subject);
  }

  deleteSubject(id: number) {
    var url = this.baseUrl + "/Subjects/Delete/" + id;
    return this.http.delete(url);
  }

  getSubject(id: number) {
    var url = this.baseUrl + "/Subjects/" + id;
    return this.http.get(url);
  }

  updateSubject(subject: any) {
    var url = this.baseUrl + "/Subjects/Update/"+subject.id
    return this.http.put(url, subject);
  }
}
