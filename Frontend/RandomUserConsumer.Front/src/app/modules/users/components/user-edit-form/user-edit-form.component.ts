import {Component, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {MatFormField, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {UserService} from "../../../../core/providers/user/user.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'paschoalotto-user-edit-form',
  standalone: true,
  imports: [
    FormsModule,
    MatFormField,
    MatLabel,
    MatInput,
    ReactiveFormsModule
  ],
  templateUrl: './user-edit-form.component.html',
  styleUrl: './user-edit-form.component.scss'
})
export class UserEditFormComponent implements OnInit {
  @Input() id?: number | undefined;
  userForm!: FormGroup;

  isLoading = true;
  isError = false;
  errorMessage = '';

  constructor(private fb: FormBuilder, private userService: UserService, private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.userForm = this.fb.group({
      contact: this.fb.group({
        email: ['', [Validators.required, Validators.email]],
        phoneNumber: [''],
        cellPhone: ['']
      }),
      account: this.fb.group({
        login: this.fb.group({
          uuid: [''],
          username: [''],
          password: ['']
        }),
        registrationDate: ['']
      }),
      id: [''],
      name: ['', Validators.required],
      birthday: [''],
      gender: [''],
      nationality: [''],
      pictureUrl: [''],
      address: this.fb.group({
        street: [''],
        number: [0],
        city: [''],
        state: [''],
        zipCode: [''],
        country: ['']
      })
    });

    this.loadUserData();
  }

  loadUserData(): void {
    this.isLoading = true;
    this.userService.getUser(this.id!).subscribe(
      (response) => {
        response.birthday = new Date(response.birthday).toISOString().split('T')[0];
        response.account.registrationDate = new Date(response.account.registrationDate).toISOString().split('T')[0];
        this.userForm.patchValue(response);
        this.isLoading = false;
      },
      (error) => {
        this.isError = true;
        this.isLoading = false;
        this.errorMessage = error.message;
        console.error('Error loading user data:', error);
      }
    )
  }

  getImageUrl(): string {
    return this.userForm.get('pictureUrl')?.value;
  }

  onSubmit() {
    console.log(this.userForm.value);
    this.isLoading = true;
    this.userService.updateUser(this.userForm.value).subscribe(
      (response) => {
        response.birthday = new Date(response.birthday).toISOString().split('T')[0];
        response.account.registrationDate = new Date(response.account.registrationDate).toISOString().split('T')[0];
        this.userForm.patchValue(response);
        this.isLoading = false;
        this.toastr.success('User updated successfully', 'Update Completed!')
      },
      (error) => {
        this.errorMessage = error.message;
        this.isLoading = false;
        this.toastr.error('Error while updating user', 'Error')
        console.error('Error updating user:', error);
      }
    )
  }
}
