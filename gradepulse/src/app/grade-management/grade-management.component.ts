import { Component, inject, OnInit } from '@angular/core';
import { NgIf,NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StudentService } from '../services/student.service';
import { SubjectService } from '../services/subject.service';
import { GradeService } from '../services/grade.service';


@Component({
  selector: 'app-grade-management',
  standalone: true,
  imports: [FormsModule,NgIf,NgFor],
  templateUrl: './grade-management.component.html',
  styleUrl: './grade-management.component.css'
})
export class GradeManagementComponent implements OnInit {

  students:any;
  subjects:any;
  // grades:Grade={
  //   studentId: '',
  //   subjectId: '',
  //   gradeValue: ''
  // };
  grades:any = {};
  studentService = inject(StudentService);
  subjectService = inject(SubjectService);
  gradeService = inject(GradeService);
  studentsWithKey: { [key: string]: string } = {};


  studentSearch:any;
  //filteredStudents

  ngOnInit(): void {
    // this.studentService.getStudents().subscribe({
    //   next:(response) =>{
    //     this.students = response;
    //     this.loadStudentWithKeys();
    //   }
    // });
    this.subjectService.getSubjects().subscribe({
      next:(response) =>{
        this.subjects = response;
        console.log(this.subjects);
      },
      error: error => console.log(error),
      complete: () => console.log("get completed")
    });    

    // this.gradeService.getGrades().subscribe({
    //   next:(response) =>{
    //     this.grades = response;        
    //   },      
    //   error: error => console.log(error),
    //   complete: () => console.log("get completed")
    // })

    this.gradeService.GetGradesGroupByStudent().subscribe({
      next:(response) =>{
        //this.subjects = response;
        this.students = response;
        console.log("Students : ", this.students )               
      },
      error: error => console.log(error),
      complete: () => console.log("get grades by student completed")
    });
  }

  loadGrades(){

  }

  saveGrades(){    
  }

  filterStudents(){

  }

  loadStudentWithKeys(){
    for(var student of this.students){
      this.studentsWithKey[student.id] = student.name 
    }
  }


}
