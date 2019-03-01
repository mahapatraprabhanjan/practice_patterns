using Autofac;
using Generic_Repo;
using Generic_Repo.Repository;
using Generic_Repo.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Generic_Repo_Consumption
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositionRoot().Resolve<UserService>().Run().ConfigureAwait(false);
        }

        private static IContainer CompositionRoot()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<GPContext>();
            dbContextOptionsBuilder.UseSqlServer("Server=tcp:127.0.0.1,5433;Database=SampleDb;User Id=sa;Password=Pass@word;");

            var builder = new ContainerBuilder();
            builder.RegisterType<UserService>().AsSelf();
            builder.RegisterType<GPContext>().WithParameter("options", dbContextOptionsBuilder.Options)
                .InstancePerLifetimeScope(); ;
            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(UnitOfWork<>))
                .As(typeof(IUnitOfWork<>));

            return builder.Build();
        }
    }
}
