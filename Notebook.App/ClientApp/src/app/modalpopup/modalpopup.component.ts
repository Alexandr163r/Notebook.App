import {Component, Inject, OnInit} from "@angular/core";
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {UserService} from "../Services/user.service";
import alertify from 'alertifyjs';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";


@Component({
  selector: 'app-modalpopup',
  templateUrl: './modalpopup.component.html',
  styleUrls: ['./modalpopup.component.css']
})

export class ModalpopupComponent implements OnInit {

  userForm: FormGroup;
  Phones: FormArray;
  respData: any;
  editData: any;

  constructor(private service: UserService, private fb: FormBuilder, private dialogRef: MatDialogRef<ModalpopupComponent>, @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {

    if (this.data.empId != null && this.data.empId != '') {
      this.LoadEditData(this.data.empId);
    }

    this.userForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(1)]],
      surname: ['', [Validators.required, Validators.minLength(1)]],
      yearOfBirth: [Number(), [Validators.min(1907), Validators.max(2023)]],
      phoneInformations: new FormArray([])
    })
  }

  Addnewrow() {
    this.Phones = this.userForm.get("phoneInformations") as FormArray;
    this.Phones.push(this.Genrow())
  }

  RemovePhone(index: any) {
    this.Phones = this.userForm.get("phoneInformations") as FormArray;
    this.Phones.removeAt(index)
  }

  get phones() {
    return this.userForm.get("phoneInformations") as FormArray;
  }

  Genrow(): FormGroup {
    return new FormGroup({
      phoneNumber: new FormControl('', [Validators.pattern(/^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$/)])
    })
  }

  SaveUser() {
    if (this.userForm.valid) {
      this.service.Save(this.userForm.value.name).subscribe(result => {
        this.respData = result;
        if (this.respData.result == 'pass') {
          alertify.success("saved successfully.")
          this.dialogRef.close();
        }
      });

    } else {
      alertify.error("Please Enter valid data")
    }
  }

  LoadEditData(id : string) {
    this.service.GetUserById(id).subscribe(user => {
      this.editData = user;
      this.userForm.setValue({id:this.editData.id,
        name:this.editData.name,
        surname:this.editData.surname,
        yearOfBirth:this.editData.yearOfBirth,
        });
      this.userForm.setControl('phones', this.fb.array(this.Phones.controls || []));
    });
  }

}
