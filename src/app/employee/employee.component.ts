import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeService } from '../service.service'; // Adjust the path as needed
import { Employee } from '../../Model/Model'; // Adjust the path as needed
import { ModelComponent } from '../assets/model/model.component';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  @ViewChild(ModelComponent, { static: true }) modelComponent!: ModelComponent;

  employees: Employee[] = [];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.employeeService.getAllEmployees().subscribe(
      (data: Employee[]) => {
        this.employees = data;
      },
      (error) => {
        console.error('Error fetching employees', error);
      }
    );
  }

  openModal(): void {
    this.modelComponent.openModal();
  }

  deleteEmployee(employee: Employee): void {
    debugger;
    console.log('Deleting employee:', employee);
    // Call your delete API here
    this.employeeService.deleteEmployee(employee.empId).subscribe(
      () => {
        // Reload employees after successful deletion
        this.loadEmployees();
      },
      (error) => {
        console.error('Error deleting employee', error);
      }
    );
  }

  updateEmployee(employee: Employee): void {
    this.modelComponent.openModal();
    console.log('Updating employee:', employee);
    // Call your update API here
    this.employeeService.updateEmployee(employee.empId).subscribe(
      () => {
        // Reload employees after successful update
        this.loadEmployees();
      },
      (error) => {
        console.error('Error updating employee', error);
      }
    );
  }

  onEmployeeAdded(employee: Employee): void {
    console.log('Adding employee:', employee);
    // Call your add API here
    this.employeeService.createEmployee(employee).subscribe(
      () => {
        // Reload employees after successful addition
        this.loadEmployees();
        this.modelComponent.closeModal();
      },
      (error) => {
        console.error('Error adding employee', error);
      }
    );
  }
}
