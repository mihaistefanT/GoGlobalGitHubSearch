import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent {
  public forecasts: GitGrubSearch[];
  private http: HttpClient;
  private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.http = http;
      this.baseUrl = baseUrl;
    }

  searchFunction(searchQuery) {
    this.http.post<GitGrubSearch[]>(this.baseUrl + 'searchresult', { "Query": searchQuery }).subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  bookmarkFunction() {
    alert("clicked me!");
  }
}

interface GitGrubSearch {
  repoName: string;
  avatar: number;
  description: number;
}
