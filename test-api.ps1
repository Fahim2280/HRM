# Test API Script

Write-Host "Testing HRM API" -ForegroundColor Green

# Test creating a user
Write-Host "Creating a test user..." -ForegroundColor Yellow

$userData = @{
    username = "admin"
    password = "Admin123!"
    role = "Administrator"
    isActive = $true
} | ConvertTo-Json

try {
    $response = Invoke-RestMethod -Uri "http://localhost:5000/api/user" -Method Post -Body $userData -ContentType "application/json"
    Write-Host "User created successfully!" -ForegroundColor Green
    Write-Host "User ID: $($response.id)" -ForegroundColor Cyan
    Write-Host "Username: $($response.username)" -ForegroundColor Cyan
    Write-Host "Role: $($response.role)" -ForegroundColor Cyan
} catch {
    Write-Host "Error creating user: $($_.Exception.Message)" -ForegroundColor Red
    if ($_.ErrorDetails) {
        Write-Host "Error details: $($_.ErrorDetails)" -ForegroundColor Red
    }
}

# Test login
Write-Host "Testing login..." -ForegroundColor Yellow

$loginData = @{
    username = "admin"
    password = "Admin123!"
} | ConvertTo-Json

try {
    $loginResponse = Invoke-RestMethod -Uri "http://localhost:5000/api/login" -Method Post -Body $loginData -ContentType "application/json"
    Write-Host "Login successful!" -ForegroundColor Green
    Write-Host "Token: $($loginResponse.token)" -ForegroundColor Cyan
    Write-Host "Username: $($loginResponse.username)" -ForegroundColor Cyan
    Write-Host "Role: $($loginResponse.role)" -ForegroundColor Cyan
    
    # Save token for future requests
    $token = $loginResponse.token
    
    # Test getting users (requires authentication)
    Write-Host "Testing authenticated request to get users..." -ForegroundColor Yellow
    try {
        $headers = @{
            Authorization = "Bearer $token"
        }
        $usersResponse = Invoke-RestMethod -Uri "http://localhost:5000/api/user" -Method Get -Headers $headers
        Write-Host "Users retrieved successfully!" -ForegroundColor Green
        Write-Host "Number of users: $($usersResponse.Count)" -ForegroundColor Cyan
    } catch {
        Write-Host "Error getting users: $($_.Exception.Message)" -ForegroundColor Red
    }
} catch {
    Write-Host "Error during login: $($_.Exception.Message)" -ForegroundColor Red
    if ($_.ErrorDetails) {
        Write-Host "Error details: $($_.ErrorDetails)" -ForegroundColor Red
    }
}