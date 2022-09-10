using Lr1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Lr1.Animals
{
    public class AnimalService
    {
        static List<Animal> AnimalList = new();


        public static async Task<IEnumerable<Animal>> GetAnimal()
        {
            if (AnimalList?.Count > 0)
                return AnimalList;

            using var stream = await FileSystem.OpenAppPackageFileAsync("Animal.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            AnimalList = JsonSerializer.Deserialize<List<Animal>>(contents);

            return AnimalList;

        }
    }
}
