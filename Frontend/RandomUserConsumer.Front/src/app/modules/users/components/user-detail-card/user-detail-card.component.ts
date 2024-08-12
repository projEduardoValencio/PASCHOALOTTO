import {Component, Input} from '@angular/core';
import {IResponseUserDetail} from "../../../../core/interfaces/responses/IResponseUserDetail";
import {userResponseDetailMock} from "../../../../core/mock/UserResponseDetailMock";
import DateUtils from "../../../../shared/utils/DateUtils";

@Component({
  selector: 'paschoalotto-user-detail-card',
  standalone: true,
  imports: [],
  templateUrl: './user-detail-card.component.html',
  styleUrl: './user-detail-card.component.scss'
})
export class UserDetailCardComponent {
  @Input() user: IResponseUserDetail = userResponseDetailMock;

  protected readonly DateUtils = DateUtils;
}
