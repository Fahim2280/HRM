# IDepartmentRepository Interface Documentation

## Overview

The `IDepartmentRepository` interface defines the contract for data access operations related to departments. It provides methods for creating, retrieving, updating, and deleting department records in the data store.

## Methods

### GetAllAsync

```csharp
Task<IEnumerable<Department>> GetAllAsync()
```

Retrieves all departments from the data store.

**Returns:** A collection of [Department](../Entities/Department.md) entities representing all departments

---

### GetByIdAsync

```csharp
Task<Department?> GetByIdAsync(int id)
```

Retrieves a specific department by its unique identifier.

**Parameters:**
- `id` (int): The unique identifier of the department to retrieve

**Returns:** A [Department](../Entities/Department.md) entity if found, or null if not found

---

### AddAsync

```csharp
Task<Department> AddAsync(Department department)
```

Adds a new department record to the data store.

**Parameters:**
- `department` ([Department](../Entities/Department.md)): The department entity to add

**Returns:** The added [Department](../Entities/Department.md) entity with updated ID

---

### UpdateAsync

```csharp
Task<Department> UpdateAsync(Department department)
```

Updates an existing department record in the data store.

**Parameters:**
- `department` ([Department](../Entities/Department.md)): The department entity with updated information

**Returns:** The updated [Department](../Entities/Department.md) entity

---

### DeleteAsync

```csharp
Task<bool> DeleteAsync(int id)
```

Deletes a department record from the data store.

**Parameters:**
- `id` (int): The unique identifier of the department to delete

**Returns:** True if the department was successfully deleted, false if not found

## Implementation

The interface is implemented by the [DepartmentRepository](../../HRM.Infrastructure/Repositories/DepartmentRepository.md) class, which contains the actual data access implementation using Entity Framework Core.

## Dependencies

The repository depends on:
- Entity Framework Core DbContext for database operations
- The [Department](../Entities/Department.md) entity class