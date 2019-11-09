import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/_models/User';

@Component({
  selector: 'app-membes-card',
  templateUrl: './membes-card.component.html',
  styleUrls: ['./membes-card.component.css']
})
export class MembesCardComponent implements OnInit {
@Input() user: User;
  constructor() { }

  ngOnInit() {
  }

}
