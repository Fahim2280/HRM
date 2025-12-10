using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class TestClient
{
    private static readonly HttpClient client = new HttpClient();
    
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Testing HRM API");
        
        // Test creating a user
        await TestCreateUser();
        
        // Test login
        await TestLogin();
    }
    
    private static async Task TestCreateUser()
    {
        try
        {
            Console.WriteLine("Creating a test user...");
            
            var userData = new
            {
                username = "admin",
                password = "Admin123!",
                role = "Administrator",
                isActive = true
            };
            
            var json = JsonSerializer.Serialize(userData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync("http://localhost:5000/api/user", content);
            
            Console.WriteLine($"Create user status: {response.StatusCode}");
            
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"User created successfully: {responseString}");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error creating user: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during user creation: {ex.Message}");
        }
    }
    
    private static async Task TestLogin()
    {
        try
        {
            Console.WriteLine("Testing login...");
            
            var loginData = new
            {
                username = "admin",
                password = "Admin123!"
            };
            
            var json = JsonSerializer.Serialize(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync("http://localhost:5000/api/login", content);
            
            Console.WriteLine($"Login status: {response.StatusCode}");
            
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Login successful: {responseString}");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error during login: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during login: {ex.Message}");
        }
    }
}