import { Component } from "@angular/core";
import { Subject } from "rxjs";
import { AuthService } from "../core/auth.service";
import { Router } from "@angular/router";
import { tap } from "rxjs/operators";

@Component({
  templateUrl: "./login-page.component.html",
  styleUrls: ["./login-page.component.css"],
  selector: "app-login-page"
})
export class LoginPageComponent { 
  constructor(
    private readonly _authService: AuthService,
    private readonly _router: Router
    ) {

  }

  public tryToLogin() {
    this._authService.tryToLogin({
      username: "quinntynebrown@gmail.com",
      password:"P@ssw0rd"
    })
      .subscribe(() => this._router.navigateByUrl("/"));
  }
  
  public onDestroy: Subject<void> = new Subject<void>();

  ngOnDestroy() {
    this.onDestroy.next();	
  }
}
