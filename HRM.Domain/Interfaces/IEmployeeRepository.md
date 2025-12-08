# IEmployeeRepository Interface Documentation

## Overview

The `IEmployeeRepository` interface defines the contract for data access operations related to employees. It provides methods for creating, retrieving, updating, and deleting employee records in the data store.

## Methods

### GetAllAsync

```csharp
Task<IEnumerable<Employee>> GetAllAsync()
```

Retrieves all employees from the data store.

**Returns:** A collection of [Employee](../Entities/Employee.md) entities representing all employees

---

### GetByIdAsync

```csharp
Task<Employee?> GetByIdAsync(int id)
```

Retrieves a specific employee by their unique identifier.

**Parameters:**
- `id` (int): The unique identifier of the employee to retrieve

**Returns:** An [Employee](../Entities/Employee.md) entity if found, or null if not found

---

### AddAsync

```csharp
Task<Employee> AddAsync(Employee employee)
```

Adds a new employee record to the data store.

**Parameters:**
- `employee` ([Employee](../Entities/Employee.md)): The employee entity to add

**Returns:** The added [Employee](../Entities/Employee.md) entity with updated ID

---

### UpdateAsync

```csharp
Task<Employee> UpdateAsync(Employee employee)
```

Updates an existing employee record in the data store.

**Parameters:**
- `employee` ([Employee](../Entities/Employee.md)): The employee entity with updated information

**Returns:** The updated [Employee](../Entities/Employee.md) entity

---

### DeleteAsync

```csharp
Task<bool> DeleteAsync(int id)
```

Deletes an employee record from the data store.

**Parameters:**
- `id` (int): The unique identifier of the employee to delete

**Returns:** True if the employee was successfully deleted, false if not found

## Implementation

The interface is implemented by the [EmployeeRepository](../../HRM.Infrastructure/Repositories/EmployeeRepository.md) class, which contains the actual data access implementation using Entity Framework Core.

## Dependencies

The repository depends on:
- Entity Framework Core DbContext for database operations
- The [Employee](../Entities/Employee.md) entity class