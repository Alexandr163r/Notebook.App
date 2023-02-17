import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { UsersComponent } from './users/users.component';
import {MaterialModule} from '../material-module';
import {ModalpopupComponent} from "./modalpopup/modalpopup.component";
import {NoopAnimationsModule} from "@angular/platform-browser/animations";
import { MatSelectModule} from "@angular/material/select";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatChipsModule} from "@angular/material/chips";
import {MatIconModule} from "@angular/material/icon";
import {MatCardModule} from "@angular/material/card";
import {MatDialogModule} from "@angular/material/dialog";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    UsersComponent,
    ModalpopupComponent,

  ],
    imports: [
        BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
        HttpClientModule,
        FormsModule,
        NoopAnimationsModule,
        MaterialModule,
        MatDialogModule,
        MatSelectModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            {path: 'users', component: UsersComponent},
        ]),
        MatChipsModule,
        MatIconModule,
        MatCardModule,
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
