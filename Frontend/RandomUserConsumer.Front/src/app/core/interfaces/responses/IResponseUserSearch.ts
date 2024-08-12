interface IResponseUserSearch {
  results: IUser[];
  search: string;
  totalPages: number;
  pageSize: number;
  page: number;
  totalCount: number;
}

interface IUser {
  id: number;
  name: string;
  birthday: string;
  gender: string;
  nationality: string;
  pictureUrl: string;
  address: IAddress;
  contact: IContact;
}

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

export {
  IResponseUserSearch
}
