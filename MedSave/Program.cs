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

            /*
            var newContactUser = new ContactUser { EmailUser = "testedasilva@gmail.com", PhoneNumberUser = 11912345678 };

            await contactUserRepo.AddAsync(newContactUser);

            var newUser = new UsersSys {NameUser = "Cleyton teste", Login = "cley16", PasswordUser = "cleytinho_teste", RoleUserId = 1, ProfUserId = 2, ContactUserId = newContactUser.ContactUserId };

            await userRepo.AddAsync(newUser);
            */

        }
    }
}