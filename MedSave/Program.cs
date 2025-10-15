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
            
            await userRepo.AddAsync(UsersSys); 
    }
}