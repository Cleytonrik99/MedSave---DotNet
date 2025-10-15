using MedSave.Context;
using MedSave.Model;
using MedSave.Repositories;

namespace MedSave
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting program...");

            var context = new MedSaveContext();

            var userRepo = new UsersSysRepository(context);
            var stockRepo = new StockRepository(context);
            var contactUserRepo = new ContactUserRepository(context);

            var result = await contactUserRepo.GetAllAsync();

            foreach (var contact in result)
            {
                Console.WriteLine(contact);
            }
        }
    }
}