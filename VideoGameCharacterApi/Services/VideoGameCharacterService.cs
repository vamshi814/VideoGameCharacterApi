using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {

        static List<Models.Character> characters = new List<Models.Character>
        {
            new Models.Character { Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Hero" },
            new Models.Character { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Hero" },
            new Models.Character { Id = 3, Name = "Samus Aran", Game = "Metroid", Role = "Hero" },
            //new Models.Character { Id = 4, Name = "Master Chief", Game = "Halo", Role = "Hero" },
            //new Models.Character { Id = 5, Name = "Lara Croft", Game = "Tomb Raider", Role = "Hero" }
        };
        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Character?> GetCharacterByIdAsync(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(character);
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            await Task.Delay(1000); // Simulate async operation
            return characters;
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
