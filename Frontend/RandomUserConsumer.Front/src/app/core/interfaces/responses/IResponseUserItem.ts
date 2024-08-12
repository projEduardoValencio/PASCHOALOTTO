interface IAddress {
  street: string;
  number: number;
  city: string;
  state: string;
  zipCode: string;
  country: string;
}

interface IContact {
  email: string;
  phoneNumber: string;
  cellPhone: string;
}

interface IResponseUserItem {
  id: number;
  name: string;
  birthday: string;
  gender: string;
  nationality: string;
  pictureUrl: string;
  address: IAddress;
  contact: IContact;
}

export {
  IResponseUserItem,
}
