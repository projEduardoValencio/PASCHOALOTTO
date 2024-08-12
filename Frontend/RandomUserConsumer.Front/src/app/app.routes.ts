import { Routes } from '@angular/router';
import {HomeComponent as UsersHomePage} from "./modules/users/pages/home/home.component";
import {UserDetailComponent as UserDetailPage} from "./modules/users/pages/detail/user-detail.component";
import {UserEditComponent as UserEditPage} from "./modules/users/pages/edit/user-edit.component";
import {ReportComponent as UserReportPage} from "./modules/users/pages/report/report.component";

export const routes: Routes = [
  {
    path: '',
    component: UsersHomePage
  },
  {
    path: 'user/detail/:id',
    component: UserDetailPage
  },
  {
    path: 'user/edit/:id',
    component: UserEditPage
  },
  {
    path: 'user/report',
    component: UserReportPage
  },
  // Default route
  {
    path: '**',
    component: UsersHomePage
  },
];
