using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.APIConsumer.ClientFactory;
using CarRentalLogicServer.GraphQLResolvers.Mutation;
using CarRentalLogicServer.GraphQLResolvers.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            
            //Httpclient factory - needed to make sure all the WebService classes have the same client
            services.AddSingleton<IHttpClientFactory, HttpClientFactory>();
            
            services
                .AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                .AddType<CustomerResolver>()
                .AddType<EmployeeResolver>()
                .AddType<ReservationResolver>()
                .AddType<VehicleResolver>()
                .AddMutationType(m => m.Name("Mutation"))
                .AddType<VehicleMutationResolver>()
                ;
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