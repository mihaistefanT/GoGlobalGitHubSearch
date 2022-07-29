import { Component } from '@angular/core';

@Component({
  selector: 'app-bookmark-component',
  templateUrl: './bookmark.component.html'
})
export class BookmarkComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
