using MedSave.Context;
using MedSave.Repositories;

namespace MedSave
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Iniciando programa...");

            var context = new MedSaveContext();

            var userRepo = new UsersSysRepository(context);
            var stockRepo = new StockRepository(context);

            var result = await stockRepo.GetByIdAsync(15); // StockId: 15, Quantity: 175, BatchId: 15, MedicineId: 15,  LocationIdStock: 15

            Console.WriteLine($"Antigo = {result}");

            result.Quantity = 1;
            result.BatchId = 15;
            result.MedicineId = 15;
            result.LocationIdStock = 15;

            Console.WriteLine($"Novo = {result}");

            await stockRepo.UpdateAsync(result);
        }
    }
}