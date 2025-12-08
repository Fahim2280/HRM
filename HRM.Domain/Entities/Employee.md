# Employee Entity Documentation

## Overview

The `Employee` entity represents an employee in the organization. It contains all essential information about an employee including personal details, employment information, and department association.

## Properties

| Property       | Type          | Required | Description                                      |
|----------------|---------------|----------|--------------------------------------------------|
| Id             | int?          | No       | Unique identifier for the employee               |
| FirstName      | string        | Yes      | Employee's first name (max 50 characters)        |
| LastName       | string        | Yes      | Employee's last name (max 50 characters)         |
| Email          | string        | Yes      | Employee's email address (max 100 characters)    |
| PhoneNumber    | string?       | No       | Employee's phone number (max 20 characters)      |
| DateOfBirth    | DateTime      | Yes      | Employee's date of birth                         |
| HireDate       | DateTime      | Yes      | Date when the employee was hired                 |
| Salary         | decimal       | Yes      | Employee's salary                                |
| IsActive       | bool          | Yes      | Indicates if the employee is currently active    |
| CreatedDate    | DateTime      | Yes      | Timestamp when the record was created            |
| ModifiedDate   | DateTime?     | No       | Timestamp when the record was last modified      |
| DepartmentId   | int           | Yes      | Foreign key linking to the Department entity     |
| Department     | Department    | Yes      | Navigation property to the Department entity     |

## Relationships

- **Department**: Many-to-One relationship with the Department entity
  - An employee belongs to one department
  - A department can have many employees

## Database Configuration

The Employee entity is configured in the database with the following constraints:

1. **Primary Key**: `Id` field with auto-increment
2. **Required Fields**: 
   - `FirstName` (max 50 characters)
   - `LastName` (max 50 characters)
   - `Email` (max 100 characters, unique index)
3. **Optional Fields**:
   - `PhoneNumber` (max 20 characters)
4. **Special Formatting**:
   - `Salary` stored as `decimal(18,2)`
5. **Foreign Key Relationship**:
   - `DepartmentId` references the `Departments` table
   - Delete behavior is set to `Restrict` to prevent accidental deletion of departments with employees

## Usage Notes

1. The `Id` property is nullable (`int?`) to facilitate creation operations where the ID is not yet assigned
2. The `Email` field has a unique constraint to prevent duplicate employee records
3. The `IsActive` flag defaults to `true` but can be set to `false` for inactive employees
4. The `CreatedDate` is automatically set to `DateTime.UtcNow` when a new employee is created
5. The `ModifiedDate` is nullable and should be updated whenever employee information changes