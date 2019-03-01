using Generic_Repo.UnitOfWork;
using Generic_Repo_Consumption.Domain;
using System;
using System.Threading.Tasks;

namespace Generic_Repo_Consumption
{
    public class UserService
    {
        private readonly IUnitOfWork<User> unitOfWork;

        public UserService(IUnitOfWork<User> unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task Run()
        {
            var users = await unitOfWork.GetRepository().GetAllAsync();
            foreach (var item in users)
            {
                Console.WriteLine($"{item.Id}-{item.Name}-{item.Address}");
            }
        }
    }
}
