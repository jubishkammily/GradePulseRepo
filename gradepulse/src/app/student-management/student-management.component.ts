import { Component, inject, OnInit} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { StudentService } from '../services/student.service';
import { NgIf,NgFor } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';


@Component({
  selector: 'app-student-management',
  standalone: true,
  imports: [FormsModule,NgIf,NgFor],
  templateUrl: './student-management.component.html',
  styleUrl: './student-management.component.css'
})
export class StudentManagementComponent implements OnInit { 
student:any = {
  "name":null,
  "dateOfBirth":null
}
editedStudent:any = {
  "name":null,
  "dateOfBirth":null
}
students: any;
isAddVisible:boolean = false;
studentService = inject(StudentService);
isEditVisible:boolean = false;
private changeDetectorRef = inject(ChangeDetectorRef);

ngOnInit(): void {
  this.loadStudents();
}

  onSubmit() {
    console.log("Fom Submit");
    if(this.student!=null){
      this.studentService.createStudent(this.student).subscribe({
        next: (response) => {
          console.log("post");  
          this.loadStudents();                   
        },
        error: error => console.log(error),
        complete: () => console.log("get completed")
      });
    }
    
  }

  loadStudents(){
    this.studentService.getStudents().subscribe({
      next:(response) => {        
        this.students = response;     
        this.changeDetectorRef.detectChanges(); 
      },
      error: error => console.log(error),
      complete: ()=> console.log("get completed")
    });     
  }

  showAdd(){
    this.isAddVisible = true;
  }

  hideAdd(){
    this.isAddVisible = false;
  }

  deleteStudent(id:number){
    console.log("Delete : ",id);    
    this.studentService.deleteStudent(id).subscribe({
      next:(response) => {        
        this.students = response;     
      },
      error: error => console.log(error),
      complete: ()=> console.log("delete completed")
    });       
  }

  editStudent(id:number){
    this.isEditVisible = true;
    this.studentService.getStudent(id).subscribe({
      next:(response) => {        
        this.editedStudent = response;     
        console.log("DOB : ",this.editedStudent.dateOfBirth);                        
        this.editedStudent.dateOfBirth = this.studentService.formatDate(this.editedStudent.dateOfBirth);
      },
      error: error => console.log(error),
      complete: ()=> console.log("get edit completed")
    });       
  }

  saveEdit(id:number){
    this.isEditVisible = false;
    this.studentService.updateStudent(this.editedStudent).subscribe({
      next:(response) => {  
        this.loadStudents();                  
      },
      error: error => console.log(error),
      complete: ()=> console.log("save edit completed")
    });
  }

  cancelEdit(){
    this.isEditVisible = false;
  }


}
