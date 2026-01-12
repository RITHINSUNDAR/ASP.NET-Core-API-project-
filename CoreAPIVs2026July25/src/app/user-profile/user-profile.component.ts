import { Component } from '@angular/core';
import { ConServiceService } from '../con-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-profile',
  imports: [CommonModule],
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent {
  profileImage: string = '';
  userData ={name:'',age:0,address:'',email:'',photo:'',username:'',password:''};
  constructor(private route: ActivatedRoute, private rest: ConServiceService,private router: Router) {}
  ngOnInit(): void {
    const uId = this.route.snapshot.paramMap.get('id');
   if(uId!==null){
    this.rest.getProfile(uId).subscribe(response => {
      this.userData = response;
      this.profileImage = `data:image/jpeg;base64,${this.userData.photo}`;
    });
   }
  }

}
