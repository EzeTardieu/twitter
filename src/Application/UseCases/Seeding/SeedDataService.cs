using Domain.Seeding;

namespace Application.UseCases.Seeding;

public class SeedDataService
{
    private readonly IDataSeeder _dataSeeder;

    public SeedDataService(IDataSeeder dataSeeder)
    {
        _dataSeeder = dataSeeder;
    }

    public async Task Execute(SeedDataCommand command)
    {
        await _dataSeeder.SeedAsync();
    }
}