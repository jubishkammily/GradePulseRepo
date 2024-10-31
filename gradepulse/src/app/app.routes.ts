import { Routes } from '@angular/router';
import { StudentManagementComponent } from './student-management/student-management.component';
import { SubjectManagementComponent } from './subject-management/subject-management.component';
import { GradeManagementComponent } from './grade-management/grade-management.component';

export const routes: Routes = [
    {path:"students",component:StudentManagementComponent},
    {path:"subjects",component:SubjectManagementComponent},
    {path:"grades",component:GradeManagementComponent},
    {path:"",component:GradeManagementComponent},
    {path:"**",component:GradeManagementComponent}
];
