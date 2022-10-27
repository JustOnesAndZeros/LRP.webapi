using LRP.webapi.Domain.Entities;
using LRP.webapi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LRP.webapi.tests
{
    public class RepositoryTest
    {
        private DbContextOptions<LeafContext> _contextOptions;
        
        [Fact]
        public async Task WhenUserAddedUserCountIncrementedBy1()
        {
            //arrange
            LeafContext context = GetLeafContext();

            UserRepository userRepository = new UserRepository(context);
            User user = new User
            {
                Active = false,
                Id = 7,
                FirstName = "Ben",
                LastName = "Wray"
            };

            //act
            await userRepository.Add(user);

            //assert
            Assert.Equal(2, context.Users.Count());
        }

        [Fact]
        public async Task WhenUpdateUserRepositoryCountIncrementedBy1()
        {
            //arrange
            LeafContext context = GetLeafContext();

            UserRepository userRepository = new UserRepository(context);
            User user = new User
            {
                Active = false,
                Id = 7,
                FirstName = "Ben",
                LastName = "Wray"
            };
            
            //act
            await userRepository.Update(user);

            //assert
            Assert.Equal(2, context.Users.Count());
        }

        [Fact]
        public async Task WhenColumnDoesNotExistResultIsEmpty()
        {
            //arrange
            LeafContext context = GetLeafContext();

            UserRepository userRepository = new UserRepository(context);
            User user = new User
            {
                Active = true,
                Id = 7,
                FirstName = "Ben",
                LastName = "Wray"
            };
            
            await userRepository.Add(user);

            //act
            IEnumerable<User> users = await userRepository.GetByQuery(new Dictionary<string, string> {{"aa", "7"}});

            //assert
            Assert.Empty(users);
        }
        
        [Fact]
        public async Task WhenIdIs7CountIs1()
        {
            //arrange
            LeafContext context = GetLeafContext();

            UserRepository userRepository = new UserRepository(context);
            User user = new User
            {
                Active = true,
                Id = 7,
                FirstName = "Ben",
                LastName = "Wray"
            };
            
            await userRepository.Add(user);

            //act
            IEnumerable<User> users = await userRepository.GetByQuery(new Dictionary<string, string> {{"Id", "7"}});

            //assert
            Assert.Single(users);
        }
        
        [Fact]
        public async Task WhenActiveAndFirstNameIsFirstCountIs1()
        {
            //arrange
            LeafContext context = GetLeafContext();

            UserRepository userRepository = new UserRepository(context);
            User user = new User
            {
                Active = true,
                Id = 7,
                FirstName = "Ben",
                LastName = "Wray"
            };
            
            await userRepository.Add(user);

            //act
            IEnumerable<User> users = await userRepository.GetByQuery(new Dictionary<string, string> {{"Active", "True"}, {"FirstName", "First"}});

            //assert
            Assert.Single(users);
        }
        
        [Fact]
        public async Task WhenActiveIsTrueCountIs2()
        {
            //arrange
            LeafContext context = GetLeafContext();

            UserRepository userRepository = new UserRepository(context);
            User user = new User
            {
                Active = true,
                Id = 7,
                FirstName = "Ben",
                LastName = "Wray"
            };
            
            await userRepository.Add(user);

            //act
            IEnumerable<User> users = await userRepository.GetByQuery(new Dictionary<string, string> {{"Active", "True"}});

            //assert
            Assert.Equal(2, users.Count());
        }
        
        [Fact]
        public async Task WhenValueDoesNotExistEmptyListIsReturned()
        {
            //arrange
            LeafContext context = GetLeafContext();

            UserRepository userRepository = new UserRepository(context);
            User user = new User
            {
                Active = true,
                Id = 7,
                FirstName = "Ben",
                LastName = "Wray"
            };
            
            await userRepository.Add(user);

            //act
            IEnumerable<User> users = await userRepository.GetByQuery(new Dictionary<string, string> {{"Active", "aaa"}});

            //assert
            Assert.Empty(users);
        }

        private LeafContext GetLeafContext()
        {
            _contextOptions = new DbContextOptionsBuilder<LeafContext>()
                .UseInMemoryDatabase("BloggingControllerTest")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var context = new LeafContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(new User
            {
                Active = true,
                Id = 12,
                FirstName = "First",
                LastName = "Last"
            });

            context.SaveChanges();
            return context;
        }
    }
}