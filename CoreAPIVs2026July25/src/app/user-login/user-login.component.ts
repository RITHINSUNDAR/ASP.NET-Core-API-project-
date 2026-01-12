import { Component } from '@angular/core';
import { ConServiceService } from '../con-service.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-login',
  imports: [FormsModule],
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.css'
})
export class UserLoginComponent {
  logData={Username:'',Password:''};
     loginResponse:string='';

  constructor(private ser: ConServiceService, private router: Router){}
  onLogin(){
    this.ser.login(this.logData).subscribe(response=>{
      const uid=response?.userId;
      if(uid==undefined){
        this.loginResponse= response.message;
      }else{
        this.router.navigate(['/userprofile', uid]);
      }
      //this.loginResponse = response.message;
    }, error=>{
      this.loginResponse = error;

    });
  }
}