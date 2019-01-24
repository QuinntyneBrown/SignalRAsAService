import { Component, Inject } from "@angular/core";
import { Subject } from "rxjs";
import { HubClient } from "../core/hub-client";
import { HttpClient } from "@angular/common/http";

@Component({
  templateUrl: "./home-page.component.html",
  styleUrls: ["./home-page.component.css"],
  selector: "app-home-page"
})
export class HomePageComponent { 
  constructor(
    @Inject("baseUrl") private readonly _baseUrl:string,
    private readonly _hubClient: HubClient,
    private readonly _httpClient: HttpClient
  ) {

  }

  ngOnInit() {
    //this._httpClient.get(`${this._baseUrl}api/ping`).subscribe();
  }

  public onDestroy: Subject<void> = new Subject<void>();

  ngOnDestroy() {
    this.onDestroy.next();	
  }
}
