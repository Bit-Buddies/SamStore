export interface UserData {
  accessToken: string;
  hoursToExpire: number;
  userToken: UserToken;
}

export interface UserToken {
  id: string;
  email: string;
  claims: Claim[];
}

export interface Claim {
  value: string;
  type: string;
}
