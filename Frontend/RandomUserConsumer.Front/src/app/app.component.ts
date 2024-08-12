import { Component } from '@angular/core';
import {RouterModule, RouterOutlet} from '@angular/router';
import {HeaderComponent} from "./shared/components/header/header.component";
import {FooterComponent} from "./shared/components/footer/footer.component";
import {UserService} from "./core/providers/user/user.service";
import {HttpClientModule} from "@angular/common/http";
import {MatTableModule} from "@angular/material/table";
import {MatButtonModule} from "@angular/material/button";
import {MatDialogModule} from "@angular/material/dialog";
import {DialogModule} from "@angular/cdk/dialog";
import {ToastrModule} from "ngx-toastr";

@Component({
  selector: 'app-root',
  standalone: true,
  providers: [UserService],
  imports: [
    RouterOutlet,
    HeaderComponent,
    FooterComponent,
    HttpClientModule,
    MatTableModule,
    MatButtonModule,
    RouterModule,
    ToastrModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'PASCHOALOTTO-Random-User-Consumer.Front';
}
