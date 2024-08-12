import {Component, NO_ERRORS_SCHEMA} from '@angular/core';
import {UserService} from "../../../../core/providers/user/user.service";
import {userResponseItemMock} from "../../../../core/mock/UserReponseItemMock";
import {NgForOf} from "@angular/common";
import {Router} from "@angular/router";
import {IResponseUserItem} from "../../../../core/interfaces/responses/IResponseUserItem";
import {MatIcon} from "@angular/material/icon";

interface IColum{
  name: string;
  width: number;
}
@Component({
  selector: 'paschoalotto-user-table',
  standalone: true,
  imports: [
    NgForOf,
    MatIcon,
  ],
  templateUrl: './user-table.component.html',
  styleUrl: './user-table.component.scss',
})
export class UserTableComponent {
  constructor(private userService: UserService, private router: Router) {}
  isLoading = true;

  tableData = [userResponseItemMock,userResponseItemMock];
  totalItems:number = 0;
  currentPage:number = 1;
  totalPages:number = 5;
  pageSize: number = 10;

  setHeaderStyle(column:IColum){
    return `width: ${column.width}%;`
  }

  getBirthdayDay(birthday: string): string {
    return new Date(birthday).toLocaleDateString('pt-BR');
  }

  public getAge(birthday:string):number{
    const today = new Date();
    const birthDate = new Date(birthday);
    let age = today.getFullYear() - birthDate.getFullYear();
    const m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age = age - 1;
    }
    return age
  }

  getCountryFlag(country:string){
    return `https://flagsapi.com/${country}/shiny/24.png`
  }

  teste(){
    console.log('Test');
  }

  // ngOnInit(): void {
  //   this.userService.getUsers().subscribe(
  //     data => {
  //       // Aqui você deve ajustar conforme a estrutura da resposta da sua API
  //       this.dataSource.data = data.results; // Ajuste a propriedade de acordo com a resposta da sua API
  //       this.isLoading = false;
  //     },
  //     error => {
  //       console.error('Error fetching users', error);
  //       this.isLoading = false;
  //     }
  //   );
  // }

  goToUserDetail(user:IResponseUserItem){
    this.router.navigate(['/user/detail', user.id]); // Ajuste o path
  }

  goToUserEdit(user: IResponseUserItem) {
    console.log("aQUIJKJKw")
    this.router.navigate(['/user/edit', user.id]); // Ajuste o path
  }

  loadUserList(){
    this.tableData = [userResponseItemMock, userResponseItemMock];
  }

  nextPage(){
    this.currentPage++;
    this.loadUserList();
  }

  previousPage(){
    this.currentPage--;
    this.loadUserList();
  }

}
