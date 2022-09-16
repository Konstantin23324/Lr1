using Lr1.Animals;
using Lr1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lr1.ViewModel
{
    public class AnimalViewModel : BindableObject
    {

        private Animal _selectedItem;

        AnimalService foodService = new();


        public ObservableCollection<Animal> Animals { get; } = new();

        public AnimalViewModel()
        {
            GetAnimalsAsync();
        }



        public string Desc { get; set; }


        public Animal SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                Desc = value?.Description;

                OnPropertyChanged(nameof(Desc));
            }
        }
        public ICommand AddItemCommand => new Command(() => AddNewItem());

        private void AddNewItem()
        {
            Animals.Add(new Animal
            {
                Id = Animals.Count + 1,
                Name = "Title " + Animals.Count,
                Description = "Description",
            });
        }



        async Task GetAnimalsAsync()
        {
            try
            {
                var animals = await AnimalService.GetAnimal();

                if (Animals.Count != 0)
                    Animals.Clear();

                foreach (var animal in animals)
                {
                    Animals.Add(animal);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка!",
                    $"Что-то пошло не так: {ex.Message}", "OK");

            }
        }
    }
}