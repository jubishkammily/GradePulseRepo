import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-subject-management',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './subject-management.component.html',
  styleUrl: './subject-management.component.css'
})
export class SubjectManagementComponent {

  model:any = {};
  onSubmit() {
    throw new Error('Method not implemented.');
    }
}
