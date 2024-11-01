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
students: any;
isAddVisible:boolean = false;
studentService = inject(StudentService);
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
          this.changeDetectorRef.detectChanges();         
        },
        error: error => console.log(error),
        complete: () => console.log("get completed")
      });
    }
    this.loadStudents();    
  }

  loadStudents(){
    this.studentService.getStudents().subscribe({
      next:(response) => {
        //console.log("next");
        this.students = response;     
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


}
