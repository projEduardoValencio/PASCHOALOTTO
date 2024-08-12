import {Component, NO_ERRORS_SCHEMA, OnInit} from '@angular/core';
import {UserService} from "../../../../core/providers/user/user.service";
import {userResponseItemMock} from "../../../../core/mock/UserReponseItemMock";
import {NgForOf, NgIf} from "@angular/common";
import {Router} from "@angular/router";
import {IResponseUserItem} from "../../../../core/interfaces/responses/IResponseUserItem";
import {MatIcon} from "@angular/material/icon";
import DateUtils from "../../../../shared/utils/DateUtils";
import {IResponseUserSearch} from "../../../../core/interfaces/responses/IResponseUserSearch";
import {FormsModule} from "@angular/forms";

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
    NgIf,
    FormsModule,
  ],
  templateUrl: './user-table.component.html',
  styleUrl: './user-table.component.scss',
})
export class UserTableComponent implements OnInit{
  constructor(private userService: UserService, private router: Router) {}
  isLoading = true;
  isError = false;

  tableData = [userResponseItemMock,userResponseItemMock];
  totalItems:number = 0;
  currentPage:number = 1;
  totalPages:number = 5;
  pageSize: number = 10;
  search:string = '';

  getCountryFlag(country:string){
    return `https://flagsapi.com/${country}/shiny/24.png`
  }

  teste(){
    console.log('Test');
  }

  ngOnInit(): void {
    this.loadUserList();
  }

  goToUserDetail(user:IResponseUserItem){
    this.router.navigate(['/user/detail', user.id]); // Ajuste o path
  }

  goToUserEdit(user: IResponseUserItem) {
    this.router.navigate(['/user/edit', user.id]); // Ajuste o path
  }

  loadUserList(){
    this.isLoading = true;
    this.userService.searchUsers(this.currentPage, this.pageSize, this.search).subscribe(
      (data:IResponseUserSearch) => {
        console.log('data: ', data);
        this.tableData = data.results;
        this.totalItems = data.totalCount;
        this.totalPages = data.totalPages;

        this.isLoading = false;
      },
      error => {
        console.error('Error fetching users', error);
        this.isError = true;
        this.isLoading = false;
      }
    );
  }

  nextPage(){
    this.currentPage++;
    this.loadUserList();
  }

  previousPage(){
    this.currentPage--;
    this.loadUserList();
  }

  callbackSearch(){
    console.log('Search: ', this.search);
    this.currentPage = 1;
    this.loadUserList();
  }

  callbackRefresh(){
    this.currentPage = 1;
    this.search = '';
    this.loadUserList();
  }

  protected readonly DateUtils = DateUtils;
}
