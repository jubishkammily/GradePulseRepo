import { Component, inject, OnInit} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SubjectService } from '../services/subject.service';
import { NgIf,NgFor } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-subject-management',
  standalone: true,
  imports: [FormsModule,NgIf,NgFor],
  templateUrl: './subject-management.component.html',
  styleUrl: './subject-management.component.css'
})
export class SubjectManagementComponent implements OnInit{
 
  subject:any = {
    "name":null,   
  }
  editedStudent:any = {
    "name":null,   
  }
  subjects: any;
  isAddVisible:boolean = false;
  subjectService = inject(SubjectService);
  isEditVisible:boolean = false;
  private changeDetectorRef = inject(ChangeDetectorRef);
 
  ngOnInit(): void {
    this.loadSubjects();
  }
    onSubmit() {
      console.log("Fom Submit");
      if(this.subject!=null){
        this.subjectService.createSubject(this.subject).subscribe({
          next: (response) => {
            console.log("post");  
            this.loadSubjects();                   
          },
          error: error => console.log(error),
          complete: () => console.log("get completed")
        });
      }
      
    }
  
    loadSubjects(){
      this.subjectService.getSubjects().subscribe({
        next:(response) => {
          //console.log("next");
          this.subjects = response;     
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
      this.subjectService.deleteSubject(id).subscribe({
        next:(response) => {        
          //this.students = response;     
        },
        error: error => console.log(error),
        complete: ()=> console.log("delete completed")
      });       
    }
  
    editStudent(id:number){
      this.isEditVisible = true;
      this.subjectService.getSubject(id).subscribe({
        next:(response) => {        
          this.editedStudent = response;          
        },
        error: error => console.log(error),
        complete: ()=> console.log("get edit completed")
      });       
    }
  
    saveEdit(id:number){
      this.isEditVisible = false;
      this.subjectService.updateSubject(this.editedStudent).subscribe({
        next:(response) => {  
          this.loadSubjects();                  
        },
        error: error => console.log(error),
        complete: ()=> console.log("save edit completed")
      });
    }
  
    cancelEdit(){
      this.isEditVisible = false;
    }
}
