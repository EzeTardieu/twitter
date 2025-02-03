using Domain.Entities;
using Domain.Seeding;

namespace Infrastructure.Data.Seeding;

public class DataSeeder : IDataSeeder
{
    private readonly ApplicationDbContext _context;

    public DataSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        var users = new List<User>
            {
                new User(new Guid("5fb37814-2ada-432c-bc49-f711b99020fc"),"Ezequiel","ezequiel@gmail.com"),
                new User("Maxi","maxi@gmail.com"),
                new User("Melina","melina@gmail.com"),
                new User("Ana","ana@gmail.com"),
                new User("Gaston","gaston@gmail.com"),
            };
        if (!_context.Users.Any())
        {
            _context.Users.AddRange(users);
            users[0].FollowedUsers = users.Skip(1).ToArray();
            await _context.SaveChangesAsync();
        }

        if (!_context.Tweets.Any())
        {
            var tweets = new List<Tweet>();
            foreach(var user in users)
            {
                for(int i = 1; i <= 30; i++)
                {
                    tweets.Add(new Tweet(user.Id,$"Hola, soy {user.Name} y este es mi tweet número {i}.",new DateTime(2025,1,i)));
                }
            }

            _context.Tweets.AddRange(tweets);
            await _context.SaveChangesAsync();
        }
    }
}