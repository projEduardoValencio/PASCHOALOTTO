import {Component, Inject, NO_ERRORS_SCHEMA, OnInit} from '@angular/core';
import {UserService} from "../../../../core/providers/user/user.service";
import {userResponseItemMock} from "../../../../core/mock/UserReponseItemMock";
import {NgForOf, NgIf} from "@angular/common";
import {Router} from "@angular/router";
import {IResponseUserItem} from "../../../../core/interfaces/responses/IResponseUserItem";
import {MatIcon} from "@angular/material/icon";
import DateUtils from "../../../../shared/utils/DateUtils";
import {IResponseUserSearch} from "../../../../core/interfaces/responses/IResponseUserSearch";
import {FormsModule} from "@angular/forms";
import {response} from "express";
import {MatDialog, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogTitle} from "@angular/material/dialog";
import {
  ConfirmationDeleteDialogComponent
} from "../../../../shared/components/confirmation-delete-dialog/confirmation-delete-dialog.component";
import {Dialog} from "@angular/cdk/dialog";
import {ToastrService} from "ngx-toastr";

interface IColum {
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
    MatDialogActions,
    MatDialogClose,
    MatDialogContent,
    MatDialogTitle,
  ],
  templateUrl: './user-table.component.html',
  styleUrl: './user-table.component.scss',
})
export class UserTableComponent implements OnInit {

  constructor(private userService: UserService, private router: Router, private dialog: Dialog,
              private toastr: ToastrService) {
  }

  isLoading = true;
  isError = false;
  errorMessage: string = '';

  tableData = [userResponseItemMock, userResponseItemMock];
  totalItems: number = 0;
  currentPage: number = 1;
  totalPages: number = 5;
  pageSize: number = 6;
  search: string = '';

  getCountryFlag(country: string) {
    return `https://flagsapi.com/${country}/shiny/24.png`
  }

  ngOnInit(): void {
    this.loadUserList();
  }

  goToUserDetail(user: IResponseUserItem) {
    this.router.navigate(['/user/detail', user.id]); // Ajuste o path
  }

  goToUserEdit(user: IResponseUserItem) {
    this.router.navigate(['/user/edit', user.id]); // Ajuste o path
  }

  loadUserList() {
    this.isLoading = true;
    this.userService.searchUsers(this.currentPage, this.pageSize, this.search).subscribe(
      (data: IResponseUserSearch) => {
        this.tableData = data.results;
        this.totalItems = data.totalCount;
        this.totalPages = data.totalPages;

        this.isLoading = false;
      },
      error => {
        console.error('Error fetching users', error);
        this.isError = true;
        this.errorMessage = error.message;
        this.isLoading = false;
      }
    );
  }

  nextPage() {
    this.currentPage++;
    this.loadUserList();
  }

  previousPage() {
    this.currentPage--;
    this.loadUserList();
  }

  callbackSearch() {
    this.currentPage = 1;
    this.loadUserList();
  }

  callbackRefresh() {
    this.currentPage = 1;
    this.search = '';
    this.loadUserList();
  }

  protected readonly DateUtils = DateUtils;

  callbackGenerateUser() {
    this.isLoading = true;
    this.userService.generateUser().subscribe(
      response => {
        let id = response.id
        this.router.navigate(['/user/detail', id]);
        this.isLoading = false;

        return;
      },
      error => {
        this.isError = true;
        this.isLoading = false;
        console.error('Error generating user', error);
      }
    )
  }

  deleteUser(user: IResponseUserItem) {
    this.isLoading = true;
    this.userService.deleteUser(user.id).subscribe(
      () => {
        this.isLoading = false;
        this.toastr.success(
          `User: ${user.name} deleted successfully!`,
          'Delete Completed'
        );
        this.callbackRefresh();
      },
      error => {
        this.isLoading = false;
        this.isError = true;
        console.error('Error deleting user', error);
      }
    )
  }

  openDeleteConfirmationDialog(user: IResponseUserItem) {
    const dialogRef = this.dialog.open<boolean>(ConfirmationDeleteDialogComponent, {
      width: '30%',
      data: user,
    });

    dialogRef.closed.subscribe(result => {
      if (result) {
        this.deleteUser(user);
      }
    });
  }

  gotToUserReport() {
    this.router.navigate(['/user/report']);
  }
}
