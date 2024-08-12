import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {IResponseUserDetail} from "../../../../../core/interfaces/responses/IResponseUserDetail";
import {userResponseDetailMock} from "../../../../../core/mock/UserResponseDetailMock";
import BirthdayUtils from "../../../../../shared/utils/DateUtils";
import DateUtils from "../../../../../shared/utils/DateUtils";
import {UserDetailCardComponent} from "../../../components/user-detail-card/user-detail-card.component";
import {MatIcon} from "@angular/material/icon";
import {UserService} from "../../../../../core/providers/user/user.service";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-user-detail',
  standalone: true,
  imports: [
    UserDetailCardComponent,
    MatIcon,
    NgIf
  ],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.scss'
})
export class UserDetailComponent implements OnInit {
  public id?: number;
  public user!: IResponseUserDetail;

  isLoading = true;
  isError = false;
  errorMessage = '';

  constructor(private route: ActivatedRoute, private router: Router, private userService: UserService) {
  }

  ngOnInit(): void {
    if (this.route.snapshot.paramMap.get('id')) {
      this.id = parseInt(this.route.snapshot.paramMap.get('id')!)
    } else {
      this.router.navigate(['']);
      return;
    }

    this.loadUserDetail();
  }

  loadUserDetail() {
    this.isLoading = true;
    this.userService.getUser(this.id!)
      .subscribe(
        user => {
          this.user = user;
          this.isLoading = false;
        },
        error => {
          this.isLoading = false;
          this.isError = true;
          this.errorMessage = error.message;
          console.error('Error fetching user details:', error);
        }
      );
  }

  backToList() {
    this.router.navigate(['']);
  }
}
