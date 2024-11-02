import { Component, inject, OnInit } from '@angular/core';
import { NgIf,NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StudentService } from '../services/student.service';
import { SubjectService } from '../services/subject.service';
import { GradeService } from '../services/grade.service';
import { Grade } from '../models/grade.model';


@Component({
  selector: 'app-grade-management',
  standalone: true,
  imports: [FormsModule,NgIf,NgFor],
  templateUrl: './grade-management.component.html',
  styleUrl: './grade-management.component.css'
})
export class GradeManagementComponent implements OnInit {

  allStudents:any;
  students:any;
  subjects:any;
  
  grade:Grade={
    studentId: '',
    subjectId: '',
    gradeValue: ''
  };

  gradeDelete:Grade={
    studentId: '',
    subjectId: '',
    gradeValue: ''
  };

  gradeUpdate:Grade={
    studentId: '',
    subjectId: '',
    gradeValue: ''
  };

  gradesListOfValues: string[] = ['A', 'B', 'C','D','E','F'];  

  studentService = inject(StudentService);
  subjectService = inject(SubjectService);
  gradeService = inject(GradeService);
  studentsWithKey: { [key: string]: string } = {};
  isAddVisible:boolean = false;
  isDeleteVisible:boolean = false;
  isEditVisible:boolean = false;

  selectedStudentId:any;
  

  ngOnInit(): void {
   this.loadGrades();
  }

  loadGrades(){
    this.studentService.getStudents().subscribe({
      next:(response) =>{
        this.allStudents = response;        
      }
    });
    this.subjectService.getSubjects().subscribe({
      next:(response) =>{
        this.subjects = response;
        console.log(this.subjects);
      },
      error: error => console.log(error),
      complete: () => console.log("get completed")
    });
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

  showAdd(){
    this.isAddVisible = true;
  }
  showEdit(){
    this.isEditVisible = true;
  }
  showDelete(){
    this.isDeleteVisible = true;
  }

  saveGrade(){    
    
    this.gradeService.createGrade(this.grade).subscribe({
      next:(response) =>{       
        console.log(""); 
        this.loadGrades();           
        this.isAddVisible = false;
      },
      error: error => console.log(error),
      complete: () => console.log("Add grade completed")
    });
  }

  hideAdd(){
    this.isAddVisible = false;
  }
  hideEdit(){
    this.isEditVisible = false;
  }
  hideDelete(){
    this.isDeleteVisible = false;
  }

  deleteGrade(){
    this.gradeService.deleteGrade(this.gradeDelete).subscribe({
      next:(response) =>{       
        console.log(""); 
        this.loadGrades();           
        this.isDeleteVisible = false;
      },
      error: error => console.log(error),
      complete: () => console.log("Delete grade completed")
    });

  }

  updateGrade(){
    this.gradeService.updateGrade(this.gradeUpdate).subscribe({
      next:(response) =>{       
        console.log(""); 
        this.loadGrades();           
        this.isEditVisible = false;
      },
      error: error => console.log(error),
      complete: () => console.log("Update grade completed")
    });

  }

}
