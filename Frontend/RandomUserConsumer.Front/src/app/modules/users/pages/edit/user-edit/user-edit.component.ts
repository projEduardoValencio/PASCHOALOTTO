import { Component } from '@angular/core';
import {UserEditFormComponent} from "../../../components/user-edit-form/user-edit-form.component";
import {MatIcon} from "@angular/material/icon";
import {Router} from "@angular/router";

@Component({
  selector: 'app-user-edit',
  standalone: true,
  imports: [
    UserEditFormComponent,
    MatIcon
  ],
  templateUrl: './user-edit.component.html',
  styleUrl: './user-edit.component.scss'
})
export class UserEditComponent {
  constructor(private router: Router) { }

  backToList() {
    this.router.navigate(['']);
  }
}
