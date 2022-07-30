import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-bookmark-component',
  templateUrl: './bookmark.component.html'
})
export class BookmarkComponent {

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.post<GitGrubSearch[]>(baseUrl + 'searchresult', "ceva").subscribe(result => {
  //    this.forecasts = result;
  //    console.log('mata' + this.forecasts);
  //  }, error => console.error(error));
  //}
}
