import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from "@angular/material/button";
import { MatSortModule } from "@angular/material/sort";
import { ContextMenuModule } from "ngx-contextmenu";

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { EmployeeDetailsComponent } from './components/employee-details/employee-details.component';
import { NewItemDialogComponent } from './components/new-item-dialog/new-item-dialog.component';
import { ConfirmComponent } from './components/confirm/confirm.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    EmployeeListComponent,
    EmployeeDetailsComponent,
    NewItemDialogComponent,
    ConfirmComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatPaginatorModule,
    MatTableModule,
    MatButtonModule,
    MatSortModule,
    BrowserAnimationsModule,
    ContextMenuModule.forRoot({
      useBootstrap4: true
    }),
    MatDialogModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: EmployeeListComponent },
      { path: 'employees/new', component: EmployeeDetailsComponent },
      { path: 'employees/:id', component: EmployeeDetailsComponent },
      { path: 'employees', component: EmployeeListComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [NewItemDialogComponent, ConfirmComponent]
})
export class AppModule { }
