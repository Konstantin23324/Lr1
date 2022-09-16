using Lr1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lr1.Services
{
    public class AnimalService
    {
        List<Animal> animalList = new();
        public async Task<IEnumerable<Animal>> GetFood()
        {
            if (animalList?.Count > 0)
                return animalList;
            using var stream = await FileSystem.OpenAppPackageFileAsync("Animal.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            animalList = JsonSerializer.Deserialize<List<Animal>>(contents);

            return animalList;

        }
    }
}
