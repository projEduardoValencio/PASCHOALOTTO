import {IReponseUserGenerated} from "../interfaces/responses/IResponseUserGenerated";

export const userRequestMock: IReponseUserGenerated = {
  contact: {
    email: "robin.tucker@example.com",
    phoneNumber: "(940) 431-3865",
    cellPhone: "(371) 471-2912"
  },
  account: {
    login: {
      uuid: "ce96001c-409b-4b10-957b-d4912e705526",
      username: "redswan365",
      password: "hyperion"
    },
    registrationDate: "2003-06-30T05:32:13.739Z"
  },
  id: 7,
  name: "ROBIN TUCKER",
  birthday: "1978-12-29T14:48:54.52Z",
  gender: "female",
  nationality: "US",
  pictureUrl: "https://randomuser.me/api/portraits/women/14.jpg",
  address: {
    street: "Brown Terrace",
    number: 0,
    city: "Buffalo",
    state: "South Carolina",
    zipCode: "",
    country: "United States"
  }
};
