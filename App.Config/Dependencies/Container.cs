﻿using App.Config.DIAutoRegister;
using App.Infrastructure.Database.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace App.Config.Dependencies
{
	public class Container
	{
		public static void Register(IServiceCollection services, IConfiguration configuration)
		{
			services.AddAutoMapper(typeof(Container));

			var configMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapperProfile());
			});

			var mapper = configMapper.CreateMapper();

			services.AddSingleton(mapper);

			services.AddDbContext<ApplicationContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("App.Presentation"));
			});

			var assembliesToScan = new[]
				{
					Assembly.GetExecutingAssembly(),
					Assembly.Load("App.Domain"),
					Assembly.Load("App.Infrastructure"),
					Assembly.Load("App.Application")
				};

			services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
					.Where(c => c.Name.EndsWith("Repository") ||
						   c.Name.EndsWith("Service") ||
						   c.Name.EndsWith("Validator") ||
						   c.Name.EndsWith("Resource"))
					.AsPublicImplementedInterfaces();

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder.AllowAnyHeader();
					builder.AllowAnyMethod();
					builder.AllowAnyOrigin();
				});
			});
		}

	}
}
