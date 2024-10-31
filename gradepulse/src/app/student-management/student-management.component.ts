import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-student-management',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './student-management.component.html',
  styleUrl: './student-management.component.css'
})
export class StudentManagementComponent {
model:any = {}
onSubmit() {
throw new Error('Method not implemented.');
}

}
