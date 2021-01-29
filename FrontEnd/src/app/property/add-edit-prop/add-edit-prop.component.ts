import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import {SharedService} from 'src/app/Services/shared.service';
 import{ShowPropComponent} from 'src/app/property/show-prop/show-prop.component';

@Component({
  selector: 'app-add-edit-prop',
  templateUrl: './add-edit-prop.component.html',
  styleUrls: ['./add-edit-prop.component.css']
})
export class AddEditPropComponent implements OnInit {
  constructor(private service:SharedService, private modal:ShowPropComponent) {
  }
  @ViewChild('closeModal') private closeModal: ElementRef;
  @Input() prop:any;
  id:number;
  name:string;
  description:string;
  state:string;
  type:string;
  location:string;
  area:string;
  contact:string;
  phoneContact:string;
  price:number;



  ngOnInit(): void {
    this.loadPropertyList();
  }

  loadPropertyList(){
      this.service.getPropList().subscribe(()=>{
      this.id=this.prop.id;
      this.name=this.prop.name;
      this.description=this.prop.description;
      this.state=this.prop.state;
      this.type=this.prop.type;
      this.location=this.prop.location;
      this.area=this.prop.area;
      this.contact=this.prop.contact;
      this.phoneContact=this.prop.phoneContact;
      this.price=this.prop.price;
    });
  }

  addProperty(){
    var val = {id:this.id,
                name:this.name,
                description:this.description,
                state:this.state,
                type:this.type,
                location:this.location,
                area:this.area,
                contact:this.contact,
                phoneContact:this.phoneContact,
                price:this.price};

    this.service.addProperty(val).subscribe(res=>{
      this.finallyProcess(res.message.toString());
    });
  }

  updateProperty(){
    var val = {id:this.id,
                name:this.name,
                description:this.description,
                state:this.state,
                type:this.type,
                location:this.location,
                area:this.area,
                contact:this.contact,
                phoneContact:this.phoneContact,
                price:this.price};
    this.service.updateProperty(val).subscribe(res=>{
      this.finallyProcess(res.message.toString());
    });
  }
  finallyProcess(msg:string){
    alert(msg);
  }
}
