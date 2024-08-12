import {Component, OnInit} from '@angular/core';
import {UserService} from "../../../../core/providers/user/user.service";
import {IResponseUserDetail} from "../../../../core/interfaces/responses/IResponseUserDetail";
import {NgForOf, NgIf} from "@angular/common";
import {UserDetailCardComponent} from "../../components/user-detail-card/user-detail-card.component";
import {UserReportCard} from "../../components/user-report-card/user-detail-card.component";
import {MatIcon} from "@angular/material/icon";
import {Router} from "@angular/router";

@Component({
  selector: 'app-report',
  standalone: true,
  imports: [
    NgIf,
    UserDetailCardComponent,
    NgForOf,
    UserReportCard,
    MatIcon
  ],
  templateUrl: './report.component.html',
  styleUrl: './report.component.scss'
})
export class ReportComponent implements OnInit{
  constructor(private userService: UserService, private router: Router) { }

  users: IResponseUserDetail[] = [];
  isLoading = true;
  isError = false;
  errorMessage = '';

  ngOnInit(): void {
    this.loadUsersReport();
  }

  loadUsersReport(): void {
    this.isLoading = true;
    this.userService.getUsersReport()
     .subscribe(
        users => {
          this.users = users;
          this.isLoading = false;
        },
        error => {
          console.error('Error fetching users report', error);
          this.isError = true;
          this.errorMessage = error.message;
          this.isLoading = false;
        }
      );
  }

  backToList() {
    this.router.navigate(['']);
  }

  printReport() {
    window.print();
  }
}
