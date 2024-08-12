import {Component, Input, OnInit} from '@angular/core';
import {IResponseUserDetail} from "../../../../core/interfaces/responses/IResponseUserDetail";
import DateUtils from "../../../../shared/utils/DateUtils";
import {NgIf} from "@angular/common";

@Component({
  selector: 'paschoalotto-user-detail-card',
  standalone: true,
  imports: [
    NgIf
  ],
  templateUrl: './user-detail-card.component.html',
  styleUrl: './user-detail-card.component.scss'
})
export class UserDetailCardComponent implements OnInit{
  @Input() user? : IResponseUserDetail;
  @Input() isLoading:boolean = true;

  ngOnInit(): void {
    console.log('User Detail Card ', this.user);
  }

  protected readonly DateUtils = DateUtils;
}
