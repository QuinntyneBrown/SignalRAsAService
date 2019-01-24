import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LoginPageComponent } from "./login-page.component";
import { CoreModule } from "../core/core.module";
import { RouterModule } from "@angular/router";

@NgModule({
    declarations:[
        LoginPageComponent
    ],    
    imports: [
        CommonModule,
        CoreModule,
        RouterModule
    ]
})
export class LoginModule {

}