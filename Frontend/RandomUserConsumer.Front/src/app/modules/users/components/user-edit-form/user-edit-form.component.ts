import {ChangeDetectorRef, Component, Input, OnInit} from '@angular/core';
import {IRequestUser} from "../../../../core/interfaces/request/IRequestUser";
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {userRequestMock} from "../../../../core/mock/UserRequestMock";
import {MatFormField, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {Router} from "@angular/router";

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
export class UserEditFormComponent implements OnInit{
  @Input() id?: number | undefined;
  userForm!: FormGroup;

  constructor(private fb: FormBuilder, private router: Router) {}

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
    const userData = {
      contact: {
        email: 'robin.tucker@example.com',
        phoneNumber: '(940) 431-3865',
        cellPhone: '(371) 471-2912'
      },
      account: {
        login: {
          uuid: 'ce96001c-409b-4b10-957b-d4912e705526',
          username: 'redswan365',
          password: 'hyperion'
        },
        registrationDate: '2003-06-30T05:32:13.739Z'
      },
      id: 7,
      name: 'ROBIN TUCKER',
      birthday: '1978-12-29T14:48:54.52Z',
      gender: 'female',
      nationality: 'US',
      pictureUrl: 'https://randomuser.me/api/portraits/women/14.jpg',
      address: {
        street: 'Brown Terrace',
        number: 0,
        city: 'Buffalo',
        state: 'South Carolina',
        zipCode: '',
        country: 'United States'
      }
    };

    this.userForm.patchValue(userData);
  }

  getImageUrl(): string {
    return this.userForm.get('pictureUrl')?.value;
  }

  onSubmit() {
    console.log(this.userForm.value);
  }
}
