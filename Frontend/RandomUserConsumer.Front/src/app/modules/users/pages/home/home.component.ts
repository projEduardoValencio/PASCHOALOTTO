import { Component } from '@angular/core';
import {HeaderComponent} from "../../../../shared/components/header/header.component";
import {UserCardComponent} from "../../components/user-card/user-card.component";
import {UserTableComponent} from "../../components/user-table/user-table.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeaderComponent, UserCardComponent, UserTableComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

}
