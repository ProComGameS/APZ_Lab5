using Autofac;
using AutoMapper;
using FitnessClub.BLL;
using FitnessClub.BLL.Interfaces;
using FitnessClub.BLL.Services;
using FitnessClub.DAL;
using FitnessClub.DAL.Models;



namespace APZ_Lab4_FitnessClubSolution
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // ✅ Реєстрація UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            
            builder.RegisterType<FitnessClubContext>()
                .InstancePerLifetimeScope();
            
            
            // ✅ Реєстрація сервісів
            builder.RegisterType<ClubService>().As<IClubService>().InstancePerLifetimeScope();
            builder.RegisterType<MemberService>().As<IMemberService>().InstancePerLifetimeScope();

            // ✅ Реєстрація AutoMapper
            builder.Register(ctx =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfiles());
                });
                return config.CreateMapper();
            }).As<IMapper>().SingleInstance();

            // ✅ Реєстрація репозиторіїв
            builder.RegisterType<Repository<Club>>().As<IRepository<Club>>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<Member>>().As<IRepository<Member>>().InstancePerLifetimeScope();
        }
    }
}