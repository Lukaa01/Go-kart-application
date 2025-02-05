﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Marketing_system.DA.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Marketing_system.DA.Contracts;
using Marketing_system.DA;
using Marketing_system.DA.Contracts.IRepository;
using Marketing_system.DA.Repository;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.BL.Service;

namespace Marketing_system
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            /*services.Configure<SMTPConfig>(Configuration.GetSection("SMTPConfig"));*/

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "karting-centar"));

            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().
                 AllowAnyHeader());
            });

            services.AddCors(options =>
            {
                options.AddPolicy("_mySpecificOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Mapper configuration:

            //JWT authentication
            var key = Environment.GetEnvironmentVariable("JWT_KEY") ?? "marketingsystem_secret_key";
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "marketingsystem";
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "marketingsystem-front.com";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("AuthenticationTokens-Expired", "true");
                        }

                        return Task.CompletedTask;
                    }
                };
            });

            //Authorization
            services.AddAuthorization(options =>
            {
            });

            BindServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowOrigin");

            app.UseCors("_mySpecificOrigins");


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void BindServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IVoziloService, VoziloService>();
            services.AddTransient<ICartServiceService, CartServiceService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IDebtService, DebtService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IVoucherService, VoucherService>();
            services.AddTransient<IPriceListService, PriceListItemService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ITrainingService, TrainingService>();
            services.AddTransient<IFinancialTransactionService, FinancialTransactionService>();
            services.AddTransient<IPartService, PartService>();
            services.AddTransient<IPartItemService, PartItemService>();
            services.AddTransient<IPartRequestService, PartRequestService>();
            services.AddTransient<ICompetitionService, CompetitionService>();
            services.AddTransient<ISuccessService, SuccessService>();
            services.AddTransient<ISponsorService, SponsorService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddHttpClient();
        }
    }
}
