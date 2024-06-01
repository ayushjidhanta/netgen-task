import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../Model/Model';
import { EmployeeRequest } from '../Model/Model';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = 'https://localhost:44304/api/Employee';

  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.apiUrl}/GetAllEmployees`, { headers: { 'accept': 'text/plain' } });
  }

  getEmployeeById(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/GetEmployeeById/${id}`, { headers: { 'accept': 'text/plain' } });
  }

  createEmployee(EmployeeRequest: EmployeeRequest): Observable<EmployeeRequest> {
    return this.http.post<any>(`${this.apiUrl}/CreateEmployee`, EmployeeRequest, { headers: { 'accept': 'text/plain', 'Content-Type': 'application/json' } });
  }
  deleteEmployee(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteEmployee/${id}`, { headers: { 'accept': 'text/plain' } });
  }
  updateEmployee(id: number): Observable<Employee> {
    return this.http.put<any>(`${this.apiUrl}/UpdateEmp/${id}`, { headers: { 'accept': 'text/plain' } });
  }
}
