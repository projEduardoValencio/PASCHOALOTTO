interface IContact {
  email: string;
  phoneNumber: string;
  cellPhone: string;
}

interface ILogin {
  uuid: string;
  username: string;
  password: string;
}

interface IAccount {
  login: ILogin;
  registrationDate: string; // Consider using Date if you prefer Date objects
}

interface IAddress {
  street: string;
  number: number;
  city: string;
  state: string;
  zipCode: string;
  country: string;
}

interface IResponseUserGenerated {
  contact: IContact;
  account: IAccount;
  id: number;
  name: string;
  birthday: string; // Consider using Date if you prefer Date objects
  gender: string;
  nationality: string;
  pictureUrl: string;
  address: IAddress;
}

export {
  IResponseUserGenerated
}
