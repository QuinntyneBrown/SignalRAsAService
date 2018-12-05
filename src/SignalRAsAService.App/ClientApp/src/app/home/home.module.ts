import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HomePageComponent } from "./home-page.component";
import { CoreModule } from "../core/core.module";
import { SharedModule } from "../shared/shared.module";
import { HttpClientModule } from "@angular/common/http";

@NgModule({
    declarations: [
        HomePageComponent
    ],
    imports:[
        CommonModule,
        CoreModule,
      SharedModule,
        HttpClientModule
    ]
})
export class HomeModule {

}
