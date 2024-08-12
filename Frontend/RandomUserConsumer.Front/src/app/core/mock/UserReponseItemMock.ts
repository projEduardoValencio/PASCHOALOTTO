import {IResponseUserItem} from "../interfaces/responses/IResponseUserItem";

export const userResponseItemMock: IResponseUserItem = {
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
  },
  contact: {
    email: "robin.tucker@example.com",
    phoneNumber: "(940) 431-3865",
    cellPhone: "(371) 471-2912"
  },
};
