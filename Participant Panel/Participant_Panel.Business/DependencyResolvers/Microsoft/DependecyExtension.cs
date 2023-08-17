using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Participant_Panel.Business.Interfaces;
using Participant_Panel.Business.Mappings.AutoMapper;
using Participant_Panel.Business.Services;
using Participant_Panel.Business.ValidationRules;
using Participant_Panel.DataAccess.Contexts;
using Participant_Panel.DataAccess.UnitOfWork;
using Participant_Panel.Dtos.MemberDtos;
using Participant_Panel.Entites.Domains;

namespace Participant_Panel.Business.DependencyResolvers.Microsoft
{
    public static class DependecyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ParticipantPanelContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;

                opt.User.RequireUniqueEmail = false;

            }).AddEntityFrameworkStores<ParticipantPanelContext>().AddDefaultTokenProviders();
            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new MemberProfile());
                opt.AddProfile(new DepartmentProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddTransient<IValidator<MemberCreateDto>, MemberCreateDtoValidator>();
            services.AddTransient<IValidator<MemberUpdateDto>, MemberUpdateDtoValidator>();
        }
    }
}
