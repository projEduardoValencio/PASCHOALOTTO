import { Routes } from '@angular/router';
import {HomeComponent as UsersHomePage} from "./modules/users/pages/home/home.component";

export const routes: Routes = [
  {
    path: '',
    component: UsersHomePage
  }
];
