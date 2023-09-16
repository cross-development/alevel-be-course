using HW_4_6.Dto;
using HW_4_6.Services.Abstractions;

namespace HW_4_6;

/// <summary>
/// Application entry point.
/// </summary>
public sealed class App
{
    private readonly ILocationService _locationService;
    private readonly ICategoryService _categoryService;
    private readonly IBreedService _breedService;
    private readonly IPetService _petService;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="locationService">An implementation of the <see cref="ILocationService"/> interface.</param>
    /// <param name="categoryService">An implementation of the <see cref="ICategoryService"/> interface.</param>
    /// <param name="breedService">An implementation of the <see cref="IBreedService"/> interface.</param>
    /// <param name="petService">An implementation of the <see cref="IPetService"/> interface.</param>
    public App(ILocationService locationService, ICategoryService categoryService, IBreedService breedService, IPetService petService)
    {
        _locationService = locationService;
        _categoryService = categoryService;
        _breedService = breedService;
        _petService = petService;
    }

    /// <summary>
    /// Application entry method.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task Start()
    {
        // Breeds
        await GetAllBreeds();
        await GetBreed();
        await CreateBreed();
        await UpdateBreed();

        // Categories
        await GetAllCategories();
        await GetCategory();
        await CreateCategory();
        await UpdateCategory();

        // Locations
        await GetAllLocations();
        await GetLocation();
        await CreateLocation();
        await UpdateLocation();

        // Pets
        await GetAllPets();
        await GetPet();
        await CreatePet();
        await UpdatePet();
    }

    private async Task GetAllBreeds()
    {
        Console.WriteLine("===== GetAllBreeds =====");

        var breeds = await _breedService.GetAllBreedsAsync();

        foreach (var breed in breeds)
        {
            Console.WriteLine($"Breed name: {breed.BreedName}");
            Console.WriteLine($"Breed category name: {breed.Category.CategoryName}");
        }

        Console.WriteLine();
    }

    private async Task GetBreed()
    {
        Console.WriteLine("===== GetBreed =====");

        var breed = await _breedService.GetBreedById(1);

        Console.WriteLine($"Breed name: {breed.BreedName}\n");
    }

    private async Task CreateBreed()
    {
        Console.WriteLine("===== CreateBreed =====");

        var breed = new BreedDto { Id = 5, BreedName = "Dog Breed 2" };

        var isBreedCreated = await _breedService.CreateBreed(1, breed);

        if (isBreedCreated)
        {
            Console.WriteLine("Breed has been created successfully\n");
        }
    }

    private async Task UpdateBreed()
    {
        Console.WriteLine("===== UpdateBreed =====");

        var breed = new BreedDto { Id = 4, BreedName = "Rodent Breed UPD 1" };

        var isBreedUpdated = await _breedService.UpdateBreed(4, breed);

        if (isBreedUpdated)
        {
            Console.WriteLine("Breed has been updated successfully\n");
        }
    }

    private async Task GetAllCategories()
    {
        Console.WriteLine("===== GetAllCategories =====");

        var categories = await _categoryService.GetAllCategoriesAsync();

        foreach (var category in categories)
        {
            Console.WriteLine($"Category name: {category.CategoryName}");
            Console.WriteLine($"Category type: {category.CategoryType}");
            Console.WriteLine("Category breeds:");

            foreach (var breed in category.Breeds)
            {
                Console.WriteLine($"Breed name: {breed.BreedName}");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private async Task GetCategory()
    {
        Console.WriteLine("===== GetCategory =====");

        var category = await _categoryService.GetCategoryById(1);

        Console.WriteLine($"Category name: {category.CategoryName}\n");
    }

    private async Task CreateCategory()
    {
        Console.WriteLine("===== CreateCategory =====");

        var category = new CategoryDto { Id = 7, CategoryName = "Horses", CategoryType = "Type 3" };

        var isCategoryCreated = await _categoryService.CreateCategory(category);

        if (isCategoryCreated)
        {
            Console.WriteLine("Category has been created successfully\n");
        }
    }

    private async Task UpdateCategory()
    {
        Console.WriteLine("===== UpdateCategory =====");

        var category = new CategoryDto { Id = 4, CategoryName = "Rodents UPD", CategoryType = "Type 2" };

        var isCategoryUpdated = await _categoryService.UpdateCategory(category);

        if (isCategoryUpdated)
        {
            Console.WriteLine("Category has been updated successfully\n");
        }
    }

    private async Task GetAllLocations()
    {
        Console.WriteLine("===== GetAllLocations =====");

        var locations = await _locationService.GetAllLocationsAsync();

        foreach (var location in locations)
        {
            Console.WriteLine($"Location name: {location.LocationName}");
            Console.WriteLine("Location pets:");

            foreach (var pet in location.Pets)
            {
                Console.WriteLine($"Pet name: {pet.Name}");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private async Task GetLocation()
    {
        Console.WriteLine("===== GetLocation =====");

        var location = await _locationService.GetLocationById(1);

        Console.WriteLine($"Location name: {location.LocationName}\n");
    }

    private async Task CreateLocation()
    {
        Console.WriteLine("===== CreateLocation =====");

        var location = new LocationDto { Id = 5, LocationName = "Austria" };

        var isLocationCreated = await _locationService.CreateLocation(location);

        if (isLocationCreated)
        {
            Console.WriteLine("Location has been created successfully\n");
        }
    }

    private async Task UpdateLocation()
    {
        Console.WriteLine("===== UpdateLocation =====");

        var location = new LocationDto { Id = 4, LocationName = "Italy UPD" };

        var isLocationUpdated = await _locationService.UpdateLocation(location);

        if (isLocationUpdated)
        {
            Console.WriteLine("Location has been updated successfully\n");
        }
    }

    private async Task GetAllPets()
    {
        Console.WriteLine("===== GetAllPets =====");

        var pets = await _petService.GetAllPetsAsync();

        foreach (var pet in pets)
        {
            Console.WriteLine($"Pet name: {pet.Name}");
            Console.WriteLine($"Pet age: {pet.Age}");
            Console.WriteLine($"Pet description: {pet.Description}");
            Console.WriteLine($"Pet image url: {pet.ImageUrl}");
            Console.WriteLine($"Pet category: {pet.Category.CategoryName}");
            Console.WriteLine($"Pet breed: {pet.Breed.BreedName}");
            Console.WriteLine($"Pet location: {pet.Location.LocationName}");
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private async Task GetPet()
    {
        Console.WriteLine("===== GetPet =====");

        var pet = await _petService.GetPetById(1);

        Console.WriteLine($"Pet name: {pet.Name}");
        Console.WriteLine($"Pet age: {pet.Age}");
        Console.WriteLine($"Pet description: {pet.Description}");
        Console.WriteLine($"Pet image url: {pet.ImageUrl}\n");
    }

    private async Task CreatePet()
    {
        Console.WriteLine("===== CreatePet =====");

        var pet = new PetDto { Id = 5, Age = 2, Name = "Dog 2", Description = "Some description about dog 2." };

        var isPetCreated = await _petService.CreatePet(5, 2, 1, pet);

        if (isPetCreated)
        {
            Console.WriteLine("Pet has been created successfully\n");
        }
    }

    private async Task UpdatePet()
    {
        Console.WriteLine("===== UpdatePet =====");

        var pet = new PetDto { Id = 4, Age = 2, Name = "Rodent UPD 1", Description = "Some description about rodent upd 1." };

        var isPetUpdated = await _petService.UpdatePet(4, 2, 4, pet);

        if (isPetUpdated)
        {
            Console.WriteLine("Pet has been updated successfully\n");
        }
    }
}