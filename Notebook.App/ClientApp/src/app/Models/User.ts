export interface User {
  id: string;
  name: string;
  surname: string;
  yearOfBirth: number;
  phones: {
    phoneId: string;
    phoneNumber: string;
    userId: string;
  }[];
}
