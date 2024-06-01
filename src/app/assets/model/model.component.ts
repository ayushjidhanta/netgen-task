import { Component, ElementRef, ViewChild, Output, EventEmitter } from '@angular/core';
import { Employee } from '../../../Model/Model'; 

@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.css']
})
export class ModelComponent {
  @ViewChild('myModal') myModal!: ElementRef; 
  @Output() newEmployeeAdded = new EventEmitter<Employee>();

  newEmployee: Employee = {
  empId: 0,
  empName: '',
  email: '',
  gender: '',
  phoneNumber: ''
};

  openModal() {
    if (this.myModal) {
      this.myModal.nativeElement.style.display = 'block';
    }
  }

  closeModal() {
    if (this.myModal) {
      this.myModal.nativeElement.style.display = 'none';
    }
  }

  addEmployee() {
    // Emit an event with the new employee data
    this.newEmployeeAdded.emit(this.newEmployee);
    const { empId, ...newEmployeeWithoutId } = this.newEmployee;
    // Clear the form and close the modal
    this.newEmployee = {
      empId: 0,
      empName: '',
      email: '',
      gender: '',
      phoneNumber: ''
    };
    this.closeModal();
  }
}
