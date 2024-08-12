import {Component, Inject} from '@angular/core';
import {MatDialogActions, MatDialogClose, MatDialogContent, MatDialogTitle} from "@angular/material/dialog";
import {MatButtonModule} from "@angular/material/button";
import {DIALOG_DATA, DialogRef} from "@angular/cdk/dialog";
import {IResponseUserItem} from "../../../core/interfaces/responses/IResponseUserItem";

@Component({
  selector: 'app-confirmation-delete-dialog',
  standalone: true,
  imports: [
  ],
  templateUrl: './confirmation-delete-dialog.component.html',
  styleUrl: './confirmation-delete-dialog.component.scss'
})
export class ConfirmationDeleteDialogComponent {
  constructor(public dialogRef: DialogRef<boolean>,
              @Inject(DIALOG_DATA) public data: IResponseUserItem) {}
}
