import { Component, OnInit } from '@angular/core';
import { UserDto } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-customers-management',
  templateUrl: './customers-management.component.html',
  styleUrls: ['./customers-management.component.css']
})
export class CustomersManagementComponent implements OnInit {

  customerList: UserDto[] = []

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUsersList().subscribe((list: UserDto[]) => 
      this.customerList = list)
  }

}
