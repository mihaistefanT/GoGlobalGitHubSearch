import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent {
  public forecasts: GitGrubSearch[];
  public email: GITEmail;
  private http: HttpClient;
  private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.http = http;
      this.baseUrl = baseUrl;
    }

  searchFunction(searchQuery) {
    this.http.post<GitGrubSearch[]>(this.baseUrl + 'SearchResult/search', { "Query": searchQuery }).subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  bookmarkFunction(id) {
    //;
    //let idDescription = Number(id) + 100;
    //var currentRow = document.getElementById(id);
    //console.log(currentRow);
    //var col1 = document.getElementById(id + 100);

    //this.bookmarks[1].repoName = col1.innerText; 
    //console.log(this.bookmarks[1].repoName);
    //var col2 = document.getElementById(id + 200);
    //console.log(col2);
    //var col3 = document.getElementById(id + 300);
    //console.log(col3);


    let email = prompt("Please enter a email address", "something@something.com");
    if (email != null) {
      this.http.post<GITEmail>(this.baseUrl + "SearchResult/sendEmail", { "Email": email, "Id": id }).subscribe(result => {
        this.email = result;
      }, error => console.error(error));
    } 
  }
}

interface GitGrubSearch {
  repoName: string;
  avatar: string;
  description: string;
}

interface GITEmail {
  email: string;
  id: string;
}
