import { Routes } from '@angular/router';
import { InsertDBComponent } from './insert-db/insert-db.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { UserProfileComponent } from './user-profile/user-profile.component';


export const routes: Routes = [
  { path: 'insert', component: InsertDBComponent },
  { path: '', component: UserLoginComponent },
  { path: 'userprofile/:id', component: UserProfileComponent }
];