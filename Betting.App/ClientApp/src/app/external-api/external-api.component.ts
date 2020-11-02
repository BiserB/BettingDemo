import { Component, OnInit } from '@angular/core';
import { EventDataService } from '../services/event-data.service';


@Component({
  selector: 'app-external-api',
  templateUrl: './external-api.component.html',
  styleUrls: ['./external-api.component.css']
})
export class ExternalApiComponent implements OnInit {

  eventTypes: any[];

  events: any;

  constructor(private eventService: EventDataService) { }

  ngOnInit() {

    
  }
}
