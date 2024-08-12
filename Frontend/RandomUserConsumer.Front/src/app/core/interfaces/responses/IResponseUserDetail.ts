interface IResponseUserDetail {
  id: number;
  name: string;
  birthday: string;
  gender: string;
  nationality: string;
  pictureUrl: string;
  address: Address;
  account: Account;
  contact: Contact;
  login: Login;
}

interface Address {
  street: string;
  number: number;
  city: string;
  state: string;
  zipCode: string;
  country: string;
}

interface Account {
  login: Login;
  registrationDate: string;
}

interface Contact {
  email: string;
  phoneNumber: string;
  cellPhone: string;
}

interface Login {
  uuid: string;
  username: string;
  password: string;
}

export {
  IResponseUserDetail
}
