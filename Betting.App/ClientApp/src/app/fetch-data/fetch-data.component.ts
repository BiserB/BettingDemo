import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EventDataService } from '../services/event-data.service';


export interface BettingEvent{
  eventId: number,
  eventTypeId: number,
  eventType: string,
  eventStatusId: number,
  eventStatus: string,
  eventName: string,
  oddsForFirstTeam: number,
  oddsForDraw: number,
  oddsForSecondTeam: number,
  eventStartDate: Date,
  modified: Date,
  isDeleted: boolean;
}

export interface EventType{
  id: number,
  name: string
}

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.css']
})
export class FetchDataComponent implements OnInit {

  dateNow: Date = new Date();
  events: BettingEvent[];
  notAvailable: string = "N/A";
  eventTypes: EventType[];

  isEditMode: boolean = false;

  selectedEvent: BettingEvent;

  form = new FormGroup({
    eventType: new FormControl('', Validators.required)
  });

  constructor(private dataService: EventDataService, @Inject('BASE_URL') private baseUrl: string) {    
  }

  ngOnInit() {

    this.dataService.getEventTypes(this.baseUrl)
    .subscribe(res => {
      this.eventTypes = res;
    });    

    this.dataService.getEvents(this.baseUrl)
    .subscribe(res =>{      
      this.events = res;
      console.log("events..", this.events);
    });

  }

  isPastEvent(eventStartDate){
    var ispast = new Date(eventStartDate) < this.dateNow;
    return ispast;
  }

  deleteEvent(ideventId: number){
    this.dataService.deleteEvent(this.baseUrl,ideventId)
    .subscribe(res => {
      if(res === true){
        this.events = this.events.filter(e => e.eventId != ideventId);
      }
    });
  }

  saveEventChanges(eventId: number){
    if(this.selectedEvent.eventId != eventId){
      return;
    }
    this.dataService.editEvent(this.baseUrl, this.selectedEvent)
    .subscribe(res => {
      if(res){
      var eventToUpdate = this.events.find(e => e.eventId == eventId);
      var eventIndex = this.events.indexOf(eventToUpdate);
      this.events[eventIndex] = JSON.parse(JSON.stringify(this.selectedEvent));
      this.selectedEvent = null;
      }
    });    
  }

  formatOddsForDraw(value: number){
    if (value == null){
      return "N/A";
    }
    return value.toFixed(2);
  }

  selectEvent(eventId){
    if(this.selectedEvent && this.selectedEvent.eventId == eventId){
      return;
    }
    var eventToUpdate = this.events.find(e => e.eventId == eventId);
    this.selectedEvent = JSON.parse(JSON.stringify(eventToUpdate));
  }

  changeOddsFirst($event){
    var newValue = $event.target.value;    
    this.selectedEvent.oddsForFirstTeam=+$event.target.value;
  }

  changeOddsDraw($event){
    this.selectedEvent.oddsForDraw=+$event.target.value
  }

  changeOddsSecond($event){
    this.selectedEvent.oddsForSecondTeam=+$event.target.value
  }

  log(){
    console.log("events..", this.events)
  }
}

