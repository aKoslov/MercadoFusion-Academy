import { Component, Input, OnInit } from '@angular/core';
import { UserTypes } from 'src/app/config/enums';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  @Input() userType: UserTypes = UserTypes.Guest

  constructor() { }

  ngOnInit(): void {
  }

}
