using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PatientRecord.Web.Brokers.DataTimes;
using PatientRecord.Web.Brokers.Loggings;
using PatientRecord.Web.Brokers.Storages;
using PatientRecord.Web.Services.DTOs;
using PatientRecord.Web.Services.Foundations.Appoinments;
using PatientRecord.Web.Services.Foundations.Appointments;
using PatientRecord.Web.Services.Foundations.Doctors;
using PatientRecord.Web.Services.Foundations.Patients;
using PatientRecord.Web.Services.Processings.PatientsProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecord.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)=>
            Configuration = configuration;


        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<StorageBroker>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PatientRecord.Web", Version = "v1" });
            });

            RegisterBrokers(services);
            AddFoundationServices(services);
            AddProcessingServices(services);
            services.AddAutoMapper(typeof(MappingProfile));
        }

        private static void AddProcessingServices(IServiceCollection services)
        {
            services.AddTransient<IPatientProcessing, PatientProcessing>();
        }

        private static void AddFoundationServices(IServiceCollection services)
        {
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IPatientService, PatientService>();
        }

        private static void RegisterBrokers(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<IDateTimeBroker, DateTimeBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientRecord.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
