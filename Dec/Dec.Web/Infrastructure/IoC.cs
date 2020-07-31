using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Dec.DataAccess.SessionBuilder;
using Dec.Logic.Identity;
using Dec.Logic.Interfaces.Managers;
using Dec.Logic.Interfaces.Repositories;
using Dec.Logic.Managers;
using Dec.Logic.Repositories;
using Dec.Logic.UnitOfWork;
using Dec.Shared.DTOs;
using Dec.Shared.Interfaces.UnitOfWork;
using Dec.Web.Models;
using Dec.Web.Services;
using Dec.Web.Validators;

namespace Dec.Web.Infrastructure
{
    public static class IoC
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            SetupSingletons(services, configuration);
            SetupScoped(services);
            SetupTransient(services);
        }

        private static void SetupSingletons(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(SessionFactory.BuildConfiguration(configuration.GetConnectionString("Dec"))
                .BuildSessionFactory());
            services.AddSingleton<LocalizationService>();
        }

        private static void SetupScoped(IServiceCollection services)
        {
            services.AddScoped(x => x.GetService<ISessionFactory>().OpenSession());
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Identity
            services.AddScoped<AppIdentityPersonManager, AppIdentityPersonManager>();
            services.AddScoped<AppSignInManager, AppSignInManager>();
            services.AddScoped<AppIdentityErrorDescriber, AppIdentityErrorDescriber>();

            // Managers
            services.AddScoped<IPersonManager, PersonManager>();
            services.AddScoped<IUserClaimManager, PersonClaimManager>();

            services.AddScoped<IAcceptedLawManager, AcceptedLawManager>();
            services.AddScoped<IApplySuperVisorManager, ApplySuperVisorManager>();
            services.AddScoped<IBillManager, BillManager>();
            services.AddScoped<ICountyManager, CountyManager>();
            services.AddScoped<IEducationsManager, EducationsManager>();
            services.AddScoped<IFingerPrintsManager, FingerPrintsManager>();
            services.AddScoped<INecessaryEducationsListManager, NecessaryEducationsListManager>();
            services.AddScoped<IPersonEducationsListManager, PersonEducationsListManager>();
            services.AddScoped<IPre_BillManager, Pre_BillManager>();
            services.AddScoped<IResidenceManager, ResidenceManager>();
            services.AddScoped<IResidenceListManager, ResidenceListManager>();
            services.AddScoped<ISignatoryListManager, SignatoryListManager>();
            services.AddScoped<ISuperVisorsManager, SuperVisorsManager>();
            services.AddScoped<IVoteManager, VoteManager>();
            services.AddScoped<IVoteOpportunitiesManager, VoteOpportunitiesManager>();
            services.AddScoped<IVoteSuperVisorManager, VoteSuperVisorManager>();

            // Repositories
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonClaimRepository, PersonClaimRepository>();

            services.AddScoped<IAcceptedLawRepository, AcceptedLawRepository>();
            services.AddScoped<IApplySuperVisorRepository, ApplySuperVisorRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<ICountyRepository, CountyRepository>();
            services.AddScoped<IEducationsRepository, EducationsRepository>();
            services.AddScoped<IFingerPrintsRepository, FingerPrintsRepository>();
            services.AddScoped<INecessaryEducationsListRepository, NecessaryEducationsListRepository>();
            services.AddScoped<IPersonEducationsListManager, PersonEducationsListManager>();
            services.AddScoped<IPre_BillRepository, Pre_BillRepository>();
            services.AddScoped<IResidenceRepository, ResidenceRepository>();
            services.AddScoped<IResidenceListRepository, ResidenceListRepository>();
            services.AddScoped<ISignatoryListRepository, SignatoryListRepository>();
            services.AddScoped<ISuperVisorsRepository, SuperVisorsRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();
            services.AddScoped<IVoteOpportunitiesRepository, VoteOpportunitiesRepository>();
            services.AddScoped<IVoteSuperVisorRepository, VoteSuperVisorRepository>();

        }

        private static void SetupTransient(IServiceCollection services)
        {
            // Validators
            services.AddTransient<IValidator<PersonDTO>, PersonDTOValidator>();
            services.AddTransient<IValidator<LoginModel>, LoginModelValidator>();
            services.AddTransient<IValidator<RegisterModel>, RegisterModelValidator>();
        }
    }
}
