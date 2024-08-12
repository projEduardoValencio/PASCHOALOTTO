import {Component, Input, OnInit} from '@angular/core';
import {IResponseUserDetail} from "../../../../core/interfaces/responses/IResponseUserDetail";
import DateUtils from "../../../../shared/utils/DateUtils";
import {NgIf} from "@angular/common";

@Component({
  selector: 'paschoalotto-user-report-card',
  standalone: true,
  imports: [
    NgIf
  ],
  templateUrl: './user-report-card.component.html',
  styleUrl: './user-report-card.component.scss'
})
export class UserReportCard implements OnInit{
  @Input() user? : IResponseUserDetail;

  ngOnInit(): void {
  }

  protected readonly DateUtils = DateUtils;
}
