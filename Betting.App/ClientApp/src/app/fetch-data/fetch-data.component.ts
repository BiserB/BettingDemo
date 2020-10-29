import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public data: Data[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Data[]>(baseUrl + 'data').subscribe(result => {
      this.data = result;
      console.log("res..", result);
    }, error => console.error(error));
  }
}

interface Data {
  id: number;
  description: string;
}
