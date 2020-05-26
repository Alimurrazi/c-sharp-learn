import { Component, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';
  private hubConnection: signalR.HubConnection;
  public data;
  public bradcastedData;

  constructor(private http: HttpClient){
  }

  ngOnInit(){
  this.startConnection();
  this.addTransferChartDataListener();
 // this.startHttpRequest();
  }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl('https://localhost:5001/message')
                            .build();
 
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }
 
  public addTransferChartDataListener = () => {
    this.hubConnection.on('send', (data) => {
      this.data = data;
      console.log(data);
    });
  }

  private startHttpRequest = () => {
    this.http.post('https://localhost:5001/api/message','hello')
      .subscribe(res => {
        console.log(res);
      })
  }
}
