import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/_models/User';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-membes-card',
  templateUrl: './membes-card.component.html',
  styleUrls: ['./membes-card.component.css']
})
export class MembesCardComponent implements OnInit {
@Input() user: User;
  constructor(private authService: AuthService,
                private userService: UserService, private alertify: AlertifyService) { }

  ngOnInit() {
  }
  sendLike(id: number) {
    this.userService.sendLike(this.authService.decodedToken.nameid, id).subscribe(data => {
      this.alertify.success('You have liked: ' + this.user.knownas);
    }, error => {
      this.alertify.error(error);
    });
  }

}
