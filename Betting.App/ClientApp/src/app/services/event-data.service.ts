import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BettingEvent, EventType } from '../fetch-data/fetch-data.component';

@Injectable({
  providedIn: 'root'
})
export class EventDataService {

  
  externalApiURL = "https://api-football-v1.p.rapidapi.com/v2/events/214226";

  apiController: string = 'Data';
  apiEventAction: string = "GetEvents";
  apiEventTypesAction: string = "GetEventTypes";
  apiEventStatusesAction: string = "GetEventStatuses";
  apiDeleteEventAction: string = "DeleteEvent";
  apiEditEventAction: string = "EditEvent";

  httpOptions = {
    headers: new HttpHeaders({
      "x-rapidapi-host": "api-football-v1.p.rapidapi.com",
      "x-rapidapi-key": "7e94de5c9cmsh4e94bd1080bdca0p11ca8cjsn5bb5569d6e86",
      "useQueryString": "true"
    })
  }  

  constructor(private http: HttpClient) { }

  getEvents(baseUrl: string){
    const url = baseUrl + this.apiController + "/" + this.apiEventAction;
    return this.http.get<BettingEvent[]>(url);  
  }  

  getEventTypes(baseUrl: string){
    const url = baseUrl + this.apiController + "/" + this.apiEventTypesAction;
    return this.http.get<EventType[]>(url);  
  } 
  
  deleteEvent(baseUrl: string, eventId){
    const url = baseUrl + this.apiController + "/" + this.apiDeleteEventAction;    
    return this.http.post<boolean>(url, eventId);  
  }

  editEvent(baseUrl: string, eventModel){
    const url = baseUrl + this.apiController + "/" + this.apiEditEventAction;
    var parameter = JSON.stringify(eventModel); 
    return this.http.post<boolean>(url, eventModel);  
  }

  getAPIEvents(): Observable<any> {
    return this.http.get<any>(this.externalApiURL, this.httpOptions);    
  }  
}
