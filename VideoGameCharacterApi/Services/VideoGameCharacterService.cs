using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Models;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Dtos;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {

        private readonly AppDbContext _context;

        public VideoGameCharacterService(AppDbContext context)
        {
            _context = context;
        }

        //static List<Models.Character> characters = new List<Models.Character>
        //{
        //    new Models.Character { Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Hero" },
        //    new Models.Character { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Hero" },
        //    new Models.Character { Id = 3, Name = "Samus Aran", Game = "Metroid", Role = "Hero" },
        //    //new Models.Character { Id = 4, Name = "Master Chief", Game = "Halo", Role = "Hero" },
        //    //new Models.Character { Id = 5, Name = "Lara Croft", Game = "Tomb Raider", Role = "Hero" }
        //};
        public async Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character)
        {
            var newCharacter = new Character
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };
            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return new CharacterResponse
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Role = newCharacter.Role
            };
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var characterToDelete = await _context.Characters.FindAsync(id);
            if (characterToDelete == null)
                return false;

            _context.Characters.Remove(characterToDelete);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            //var character = characters.FirstOrDefault(c => c.Id == id);

            //var character = await _context.Characters.FindAsync(id);
            //if (character == null) return null;

            //return new CharacterResponse
            //{
            //    Name = character.Name,
            //    Game = character.Game,
            //    Role = character.Role
            //};

            return await _context.Characters
                .Where(c => c.Id == id)
                .Select(c => new CharacterResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<CharacterResponse>> GetCharactersAsync()
        {             //return Task.FromResult(characters);
            //var characters = await _context.Characters.ToListAsync();
            return await _context.Characters.Select(c => new CharacterResponse
            {
                Id = c.Id,
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).ToListAsync();
        }

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        {
            var existingCharacter = await _context.Characters.FindAsync(id);
            if (existingCharacter == null)
                return false;

            existingCharacter.Name = character.Name;
            existingCharacter.Game = character.Game;
            existingCharacter.Role = character.Role;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
