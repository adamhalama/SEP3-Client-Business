using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalClientServer.Data;
using CarRentalClientServer.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace CarRentalClientServer.Authentification
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider/*, IAuthentication*/
    {
        private readonly IJSRuntime jsRuntime;
        private readonly ILoginService loginService;
        private readonly IEmployeeService employeeService;
        private readonly ICustomerService customerService;

        private UserLogin cachedUser;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, ILoginService loginService, IEmployeeService employeeService, ICustomerService customerService)
        {
            this.jsRuntime = jsRuntime;
            this.loginService = loginService;
            this.employeeService = employeeService;
            this.customerService = customerService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    UserLogin tmp = JsonSerializer.Deserialize<UserLogin>(userAsJson);
                    if (tmp != null) await ValidateLogin(tmp.Email, tmp.Password);
                }
            }
            else
            {
                identity = await SetupClaimsForUser(cachedUser);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(string email, string password)
        {
            Console.WriteLine("Validating log in");
            if (cachedUser == null)
            {
                if (string.IsNullOrEmpty(email)) 
                {
                    //throw new Exception("Enter email");
                    Console.WriteLine("Authentication failed with no email being provided");
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    //throw new Exception("Enter password");
                    Console.WriteLine("Authentication failed with no password being provided");
                    return;
                }
            }


            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                UserLogin user;
                if (cachedUser == null)
                    user = await loginService.ValidateUser(email, password);
                else
                    user = cachedUser;
                
                identity = await SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedUser = user;
            }
            catch (Exception e)
            {
                throw new AuthenticationException(e.Message);
            }

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public void Logout()
        {
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private async Task<ClaimsIdentity> SetupClaimsForUser(UserLogin user)
        {
            if (user.IsEmployee)
            {
                var userDetails = await employeeService.GetEmployeeAsync(user.UserId);
                
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, userDetails.Name));
                claims.Add(new Claim(ClaimTypes.Email, userDetails.Email));
                claims.Add(new Claim("ID", userDetails.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, "Employee"));
                if (userDetails.ClearanceLevel < 1)
                    userDetails.ClearanceLevel = 1;
                claims.Add(new Claim("Level", userDetails.ClearanceLevel.ToString()));

                ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
                return identity;
            }
            else
            {
                var userDetails = await customerService.GetCustomerAsync(user.UserId);
                
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, userDetails.Name));
                claims.Add(new Claim(ClaimTypes.Email, userDetails.Email));
                claims.Add(new Claim("ID", userDetails.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, "Customer"));
                claims.Add(new Claim("Level", "0"));

                ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
                return identity;
            }
            
            
        }

        public UserLogin GetLoggedInUser()
        {
            return cachedUser;
        }
    }
}