import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/Services/shared.service';

@Component({
  selector: 'app-show-prop',
  templateUrl: './show-prop.component.html',
  styleUrls: ['./show-prop.component.css']
})
export class ShowPropComponent implements OnInit {

  constructor(private service:SharedService) { }

  display='none';
  PropertyList:any=[];

  ModalTitle:string='';
  ActivateAddEditPropComp:boolean=false;
  ModalAddEdit:boolean=false;
  prop:any;


  ngOnInit(): void {
    this.refreshPropList();
  }

  addClick(){
    this.prop={
      id:0,
      name:"",
      description:"",
      state:"",
      type:"",
      location:"",
      area:"",
      contact:"",
      phoneContact:"",
      price:0,
    }
    this.ModalTitle="Add Property";
    this.ModalAddEdit=true;
    this.ActivateAddEditPropComp=true;
  }

  editClick(item:any){
    console.log(item);
    this.prop=item;
    this.ModalTitle="Edit Property";
    this.ModalAddEdit=true;
    this.ActivateAddEditPropComp=true;
  }

  deleteClick(item:any){
    if(confirm('Are you sure??')){
      this.service.deleteProperty(item.id).subscribe(data=>{
        this.refreshPropList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditPropComp=false;
    this.ModalAddEdit=false;
    this.refreshPropList();
  }


  refreshPropList(){
      this.service.getPropList().subscribe(data=>{
      this.PropertyList=data.data;
    });
  }

}
