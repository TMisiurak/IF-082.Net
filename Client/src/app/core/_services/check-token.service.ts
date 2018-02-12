import { Injectable } from '@angular/core';

@Injectable()
export class CheckTokenService {
  public jwtLocal: string = "";
  public accessTokenLocal: string = "";
  public expiresInLocal: string = "";
  public tokenTypeLocal: string = "";
  public authorizationToken: string = "";

  constructor() { }

  checkToken(role: string){
    if(localStorage.getItem(role)){
      this.jwtLocal = localStorage.getItem(role);
      this.accessTokenLocal = JSON.parse(localStorage.getItem(role)).access_token;
      this.expiresInLocal = JSON.parse(localStorage.getItem(role)).expires_in;
      this.tokenTypeLocal = JSON.parse(localStorage.getItem(role)).token_type;
      this.authorizationToken = this.tokenTypeLocal + " " + this.accessTokenLocal;
      return true;
    }
    return false;
  }
}
