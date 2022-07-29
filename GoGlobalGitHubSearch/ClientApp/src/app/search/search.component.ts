import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent {
  public forecasts: GitGrubSearch[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<GitGrubSearch[]>(baseUrl + 'gitgrubsearch').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface GitGrubSearch {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
