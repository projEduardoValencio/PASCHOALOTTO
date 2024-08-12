import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {IResponseUserDetail} from "../../../../../core/interfaces/responses/IResponseUserDetail";
import {userResponseDetailMock} from "../../../../../core/mock/UserResponseDetailMock";
import BirthdayUtils from "../../../../../shared/utils/DateUtils";
import DateUtils from "../../../../../shared/utils/DateUtils";
import {UserDetailCardComponent} from "../../../components/user-detail-card/user-detail-card.component";
import {MatIcon} from "@angular/material/icon";

@Component({
  selector: 'app-user-detail',
  standalone: true,
  imports: [
    UserDetailCardComponent,
    MatIcon
  ],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.scss'
})
export class UserDetailComponent implements OnInit{
  public id?: number;
  public user: IResponseUserDetail = userResponseDetailMock;
  constructor(private route: ActivatedRoute, private router: Router) {}
  ngOnInit(): void {
    if(this.route.snapshot.paramMap.get('id')){
      this.id = parseInt(this.route.snapshot.paramMap.get('id')!)
    }else{
      this.router.navigate(['/']);
      return;
    }
  }

  backToList() {
    this.router.navigate(['/']);
  }
}
