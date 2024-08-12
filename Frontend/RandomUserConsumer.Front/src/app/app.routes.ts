import { Routes } from '@angular/router';
import {HomeComponent as UsersHomePage} from "./modules/users/pages/home/home.component";
import {UserDetailComponent as UserDetailPage} from "./modules/users/pages/detail/user-detail/user-detail.component";

export const routes: Routes = [
  {
    path: '',
    component: UsersHomePage
  },
  {
    path: 'user/detail/:id',
    component: UserDetailPage
  }
];
