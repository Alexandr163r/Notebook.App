import {Component, OnInit, ViewChild} from '@angular/core';
import { User } from "../Models/User";
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import {UserService} from "../Services/user.service";
import {MatDialog} from "@angular/material/dialog";
import {ModalpopupComponent} from "../modalpopup/modalpopup.component";
import alertify from "alertifyjs";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})

export class UsersComponent implements OnInit{
  public users: User[] = [];
  public dataSource: any;

  displayedColumns: string[] = ["name", "surname", "yearOfBirth", "phones", "edit"];

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort!: MatSort

  constructor(private service : UserService, private dialog : MatDialog) {
    }

    ngOnInit(): void {
    this.GetAll();
    this.service.RequiredRefresh.subscribe(r=>{
      this.GetAll();
    })
    }

  GetAll(){
    this.service.GetUsers().subscribe(result => {
      this.users = result;
      this.dataSource = new MatTableDataSource<User>(this.users)
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    } );
  }

  Filterchange(event : Event){
    const filtervalue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filtervalue;
  }

  FunctionEdit( id: string){
    this.OpenDialog('1000ms','600ms', id )
  }

  OpenDialog(enteranimation: any, exitanimation: any, id :string) {

    this.dialog.open(ModalpopupComponent, {
      enterAnimationDuration: enteranimation,
      exitAnimationDuration: exitanimation,
      width: "50%",
      data:{
        empId:id
      }
    })
  }

  GetRow(row: any) {
  }

  FunctionDelete(code: any) {
    alertify.confirm("Удаление","Удалить запись?",()=>{
      this.service.DeleteUserById(code).subscribe(result => {
        this.GetAll();
        alertify.success("Removed successfully.")
      });
    },function(){
    })

  }
}

