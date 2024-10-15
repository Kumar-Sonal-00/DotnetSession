using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleAPIClient
{
    internal class ApiConsumer
    {
        static string baseUrl = "http://localhost:5170/api/Employees/";

        public static void GetEmps()
        {
            //TODO call EmployeeService using HttpClient
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                //get the token from Account loginservice
                var token = GetToken();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                
                var response=client.GetAsync("GetEmps");
                response.Wait();

                //get the response status
                var resResult=response.Result;
                if (resResult.IsSuccessStatusCode)
                {
                    //read the result
                    var content=resResult.Content.ReadAsStringAsync();
                    content.Wait();
                    //get the string result of the response
                    var finalResult = content.Result;
                    //convert the json string into object
                    var lstEmps= JsonSerializer.Deserialize<List<Employee>>(finalResult);
                    //display the records
                    foreach (var e in lstEmps)
                    {
                        Console.WriteLine($"{e.ecode}\t{e.ename}\t{e.salary}\t{e.deptid}");
                    }                    
                }
            }
        }

        public static string GetToken()
        {
            string token = "";
            //call the authenticate api to get the token
            using (var client = new HttpClient())
            {
                var baseUrl = "http://localhost:5170/api/Account/authenticate";
                client.BaseAddress = new Uri(baseUrl);
                
                var response = client.PostAsJsonAsync("", new { userName = "ravi", password = "admin123", role = "admin" });
                response.Wait();
                var resResult = response.Result;
                if (resResult.IsSuccessStatusCode)
                {
                    var content = resResult.Content.ReadAsStringAsync();
                    content.Wait();
                    token = content.Result;
                }
            }
            return token;
        }
        public static void GetEmpById(int id)
        {
            //TODO call EmployeeService using HttpClient
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                var token = GetToken();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var response = client.GetAsync($"GetEmpById/{id}");
                response.Wait();

                //get the response status
                var resResult = response.Result;
                if (resResult.IsSuccessStatusCode)
                {
                    //read the result
                    var content = resResult.Content.ReadAsStringAsync();
                    content.Wait();
                    //get the string result of the response
                    var finalResult = content.Result;
                    //convert the json string into object
                    var e = JsonSerializer.Deserialize<Employee>(finalResult);
                    //display the record
                    Console.WriteLine($"{e.ecode}\t{e.ename}\t{e.salary}\t{e.deptid}");
                }
            }

        }
        public static void AddEmployee(Employee emp)
        {
            //TODO call EmployeeService using HttpClient
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                var token = GetToken();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var response =client.PostAsJsonAsync("AddEmployee", emp);
                response.Wait();
                var resResult = response.Result;
                if (resResult.IsSuccessStatusCode)
                {
                    var content = resResult.Content.ReadAsStringAsync();
                    content.Wait();
                    Console.WriteLine(content.Result);
                }
            }
        }
    }
}
