using MedSave.Context;
using MedSave.Repositories;

static void Main(string[] args)
{
    var context = new MedSaveContext();

    var userRepo = new UsersSysRepository(context);
    var stockRepo = new StockRepository(context);

    stockRepo.GetByIdAsync(1);
}