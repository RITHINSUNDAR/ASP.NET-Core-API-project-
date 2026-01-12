import { Component,OnInit } from '@angular/core';
import { ConServiceService } from '../con-service.service';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-insert-db',
  imports: [ FormsModule],
  templateUrl: './insert-db.component.html',
  styleUrl: './insert-db.component.css'
})
export class InsertDBComponent {
  userData={Name:'',Age:0,Address:'',Email:'',Username:'',Password:''};
  RegResponse:string='';
  selectedFile: File | null = null;


  constructor(public rest: ConServiceService){}
  ngOnInit():void{
  }

  addUserdata():void{
    if(this.selectedFile){
      this.rest.createUser(this.userData,this.selectedFile).subscribe(Response=>{
        this.RegResponse=Response.message;
      });
    }
  }
  onFileSelected(event:any):void{
    this.selectedFile = event.target.files[0];
  }

}
