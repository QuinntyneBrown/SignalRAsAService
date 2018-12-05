import { Injectable, NgZone, Inject } from "@angular/core";
import { HubConnection, HubConnectionBuilder, IHttpConnectionOptions } from "@aspnet/signalr";
import { Subject } from "rxjs";
import { AuthService } from "./auth.service";

@Injectable()
export class HubClient {
  public events: Subject<any> = new Subject();

  constructor(
      @Inject("baseUrl") private readonly _baseUrl:string,      
      private readonly _ngZone: NgZone) {
  }

  private _connection: HubConnection;
  private _connect: Promise<any>;

  public connect(): Promise<any> {
    if (this._connect) return this._connect;

    this._connect = new Promise((resolve, reject) => {

      const options: IHttpConnectionOptions = {
        accessTokenFactory: () => localStorage.getItem("accessToken")
      };

      this._connection = this._connection || new HubConnectionBuilder()
        .withUrl(`${this._baseUrl}hub`,options)
        .build();

      this._connection.on("ping", (value) => {
        this._ngZone.run(() => this.events.next(value));
      });

      this._connection.onclose((e) => {        
        this.disconnect();
      });

      this._connection.start()
        .then(() => resolve())
        .catch(() => reject("Failed Connection"));
    });

    return this._connect;
  }

  public disconnect() {
    if (this._connection) this._connection.stop();
    this._connect = null;
    this._connection = null;
  }  
}
