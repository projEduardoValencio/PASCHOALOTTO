import { Component } from '@angular/core';
import NewCommandModule from "@angular/cli/src/commands/new/cli";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'paschoalotto-user-card',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './user-card.component.html',
  styleUrl: './user-card.component.scss'
})
export class UserCardComponent {
}
