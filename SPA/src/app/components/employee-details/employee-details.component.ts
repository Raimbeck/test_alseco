import { NewItemDialogComponent } from './../new-item-dialog/new-item-dialog.component';
import { Employee } from './../../interfaces/employee';
import { EmployeeService } from './../../services/employee.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from '../../../../node_modules/rxjs';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';
import { MatTableDataSource } from '../../../../node_modules/@angular/material/table';
import { Item } from '../../interfaces/item';
import { MatDialog } from '../../../../node_modules/@angular/material/dialog';

@Component({
  selector: 'employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.scss']
})
export class EmployeeDetailsComponent implements OnInit, OnDestroy {
  id: number;
  employee: Employee;
  dataSource: MatTableDataSource<Item>;
  displayedColumns: string[] = ['name', 'cost', 'action'];

  employeeSub: Subscription;
  editEmployeeSub: Subscription;
  dialogSub: Subscription;

  constructor(private service: EmployeeService, private route: ActivatedRoute, public dialog: MatDialog, private router: Router) { }

  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));
    if(this.id)
      this.employeeSub = this.service.getEmployee(this.id).subscribe(response => {
        this.employee = response;
        this.rebuildTable();
      });

    else {
      this.employee = new Employee();
      this.rebuildTable();
    }
  }

  getTotal() {
    let total = 0;
    this.employee.items.forEach(item => total += item.cost);
    return total;
  }

  addItem() {
    const dialogRef = this.dialog.open(NewItemDialogComponent, {
      width: '30%',
      data: {
        item: new Item(),
        actions: true
      }
    });

    this.dialogSub = dialogRef.afterClosed().subscribe(item => {
      if(item) {
        this.employee.items.push(item);
        this.rebuildTable();
      }
    });
  }
  
  deleteItem(item: Item) {
    let index = this.employee.items.indexOf(item);
    if(index > -1) {
      this.employee.items.splice(index, 1);
      this.rebuildTable();
    }
  }

  editItem(item: Item) {
    const dialogRef = this.dialog.open(NewItemDialogComponent, {
      width: '30%',
      data: {
        item: item,
        actions: false
      }
    });
  }

  rebuildTable() {
    this.dataSource = new MatTableDataSource(this.employee.items);
  }

  save() {
    this.editEmployeeSub = this.id
      ? this.service.updateEmployee(this.id, this.employee).subscribe(response => {
        if(response)
          this.router.navigate(['/employees']);
      })
      : this.service.createEmployee(this.employee).subscribe(response => {
        if(response)
          this.router.navigate(['/employees']);
      });
  }

  ngOnDestroy() {
    if(this.employeeSub) this.employeeSub.unsubscribe();
    if(this.editEmployeeSub) this.editEmployeeSub.unsubscribe();
    if(this.dialogSub) this.dialogSub.unsubscribe();
  }
}
