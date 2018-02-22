import { Injectable } from '@angular/core';

@Injectable()
export class JwtDecoderService {

  constructor() { }

  public getJwtPayload(jwt: string): any{
    let accessToken: string = JSON.parse(jwt).access_token;
    let payload: string = accessToken.split('.')[1];
    let decodedPayload = window.atob(payload);
    let parsedPayload = JSON.parse(decodedPayload);
    return parsedPayload;
  }
}
