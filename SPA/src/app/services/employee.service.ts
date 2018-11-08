import { Filter } from './../interfaces/filter';
import { Employee } from './../interfaces/employee';
import { Injectable, isDevMode } from '@angular/core';
import { HttpClient } from '../../../node_modules/@angular/common/http';
import { Observable } from '../../../node_modules/rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private url: string = isDevMode() ? 'https://localhost:5001/api/employees' : 'https://alsecoapp.azurewebsites.net/api/employees';

  constructor(private http: HttpClient) { }

  //HttpGet api/employees
  public getEmployees(filter: Filter): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.url}${this.toQueryString(filter)}`);
  }

  //HttpGet api/employees/{id}
  public getEmployee(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.url}/${id}`);
  }

  //HttpPost api/employees
  public createEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(`${this.url}`, employee);
  }

  //HttpPut api/employees/{id}
  public updateEmployee(id: number, employee: Employee): Observable<boolean> {
    return this.http.put<boolean>(`${this.url}/${id}`, employee);
  }

  //HttpDelete api/employees/{id}
  public deleteEmployee(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.url}/${id}`);
  }

  //HttpGet api/employees/count
  public getEmployeesCount(): Observable<number> {
    return this.http.get<number>(`${this.url}/count`);
  }

  private toQueryString(filter: Filter) {
    return `?pageIndex=${filter.pageIndex}&pageSize=${filter.pageSize}`;
  }

}
