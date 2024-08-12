import {Component, OnInit} from '@angular/core';
import {UserEditFormComponent} from "../../../components/user-edit-form/user-edit-form.component";
import {MatIcon} from "@angular/material/icon";
import {ActivatedRoute, Router} from "@angular/router";

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
export class UserEditComponent implements OnInit{
  id?: number;
  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    if (this.route.snapshot.paramMap.get('id')) {
      this.id = parseInt(this.route.snapshot.paramMap.get('id')!)
    }else{
      this.router.navigate(['']);
    }
  }

  backToList() {
    this.router.navigate(['']);
  }
}
