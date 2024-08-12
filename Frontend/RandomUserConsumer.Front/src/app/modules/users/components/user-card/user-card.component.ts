import {Component, Input} from '@angular/core';
import {IResponseUserItem} from "../../../../core/interfaces/responses/IResponseUserItem";
import {userResponseItemMock} from "../../../../core/mock/UserReponseItemMock";
import {findPackageJson} from "@angular/cli/src/utilities/package-tree";
import {MatIcon} from "@angular/material/icon";

@Component({
  selector: 'paschoalotto-user-card',
  standalone: true,
  imports: [
    MatIcon
  ],
  templateUrl: './user-card.component.html',
  styleUrl: './user-card.component.scss',
})
export class UserCardComponent {
  @Input() userProperty: IResponseUserItem | undefined;
  public user: IResponseUserItem = userResponseItemMock;
  protected readonly Date = Date;
  public userBirthdayFormat(){
    return new Date(this.user.birthday).toLocaleDateString('pt-BR')
  };
  public userAge():number{
    const today = new Date();
    const birthDate = new Date(this.user.birthday);
    let age = today.getFullYear() - birthDate.getFullYear();
    const m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age = age - 1;
    }
    return age
  }
  public flagUrl = `https://flagsapi.com/${this.user.nationality}/shiny/24.png`
  public genderIcon(){
    switch (this.user.gender){
      case 'male':
        return 'male';
      case 'female':
        return 'female';
      default:
        return 'person';
    }
  }
}
