import { ConfirmComponent } from './../confirm/confirm.component';
import { Filter } from './../../interfaces/filter';
import { Employee } from './../../interfaces/employee';
import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { MatTableDataSource } from '../../../../node_modules/@angular/material/table';
import { Subscription, Observable } from '../../../../node_modules/rxjs';
import { PageEvent } from '../../../../node_modules/@angular/material/paginator';
import { Router } from '../../../../node_modules/@angular/router';
import { MatSort } from '../../../../node_modules/@angular/material/sort';
import { ContextMenuComponent } from '../../../../node_modules/ngx-contextmenu';
import { MatDialog } from '../../../../node_modules/@angular/material/dialog';

@Component({
  selector: 'employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit, OnDestroy {
  displayedColumns: string[] = ['name', 'count', 'total'];
  dataSource: MatTableDataSource<Employee>;
  employeesCount$: Observable<number>;

  filter: Filter = {
    pageIndex: 0,
    pageSize: 10
  }

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(ContextMenuComponent) public menu: ContextMenuComponent;

  employeeSub: Subscription;
  editEmployeeSub: Subscription;
  dialogSub: Subscription;

  constructor(private service: EmployeeService, private router: Router, public dialog: MatDialog) { }

  ngOnInit() {
    this.getEmployees();
  }

  getEmployees() {
    this.employeeSub = this.service.getEmployees(this.filter).subscribe(response => {
      this.employeesCount$ = this.service.getEmployeesCount();

      response.forEach(employee => {
        employee['total'] = this.getTotal(employee);
        employee['count'] = employee.items.length;
        employee['shortName'] = this.toShortName(employee);
      });

      this.dataSource = new MatTableDataSource(response);
      this.dataSource.sort = this.sort;
    });
  }

  delete(employee: Employee) {
    const dialogRef = this.dialog.open(ConfirmComponent, {
      width: '20%',
      data: {
        title: 'Delete',
        message: 'Are you sure you want to delete this employee?'
      }
    });

    this.dialogSub = dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.editEmployeeSub = this.service.deleteEmployee(employee.id).subscribe(response => {
          this.getEmployees();
        });
      }
    });
  } 

  search(input: HTMLInputElement) {
    this.dataSource.filter = input.value.trim().toLowerCase();
  }

  getTotal(employee: Employee): number {
    let total = 0;
    employee.items.forEach(item => total += item.cost);
    return total;
  }

  toShortName(employee: Employee): string {
    let result = `${employee.name} ${employee.surname.substr(0, 1)}.`;
    result += employee.patronymic ? employee.patronymic.substr(0, 1) + '.' : '';

    return result;
  }

  navigate(employee: Employee) {
    this.router.navigate([`/employees/${employee.id}`]);
  }

  select(rowId: number) {
    var activeRow = document.querySelector('.mat-row.active');
    if(activeRow)
      activeRow.classList.remove('active');

    document.getElementById(`row_${rowId}`).classList.add('active');
  }

  onPageChange(page: PageEvent) {
    this.filter.pageIndex = page.pageIndex;
    this.getEmployees();
  }
  
  ngOnDestroy() {
    if(this.employeeSub) this.employeeSub.unsubscribe();
    if(this.dialogSub) this.dialogSub.unsubscribe();
    if(this.editEmployeeSub) this.editEmployeeSub.unsubscribe();
  }
}
