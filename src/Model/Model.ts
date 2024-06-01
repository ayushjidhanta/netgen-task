export interface Employee {
  empId: number;
  empName: string;
  gender: string;
  email: string;
  phoneNumber: string;
}

export interface EmployeeRequest {
  empId?: number;
  empName: string;
  gender: string;
  email: string;
  phoneNumber: string;
}
