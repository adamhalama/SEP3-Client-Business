using CarRentalLogicServer.Factories;
using CarRentalLogicServer.GraphQLResolvers.Mutations;
using CarRentalLogicServer.GraphQLResolvers.Queries;
using CarRentalLogicServer.Services.Classes;
using CarRentalLogicServer.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRentalLogicServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Interfaces
            services.AddScoped<ICustomerService, CustomerWebService>();
            services.AddScoped<IEmployeeService, EmployeeWebService>();
            services.AddScoped<IReservationService, ReservationWebService>();
            services.AddScoped<IVehicleService, VehicleWebService>();
            services.AddScoped<ILoginService, LoginWebService>();
            
            services
                .AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                .AddType<CustomerResolver>()
                .AddType<EmployeeResolver>()
                .AddType<ReservationResolver>()
                .AddType<VehicleResolver>()
                .AddMutationType(m => m.Name("Mutation"))
                .AddType<VehicleMutationResolver>()
                .AddType<CustomerMutationResolver>()
                .AddType<EmployeeMutationResolver>()
                .AddType<ReservationMutationResolver>()
                .AddType<LoginMutationResolver>()
                ;
            services.AddSingleton<IHttpClientFactory, HttpClientFactory>();
            //Httpclient factory - needed to make sure all the WebService classes have the same client
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });
        }
    }
}