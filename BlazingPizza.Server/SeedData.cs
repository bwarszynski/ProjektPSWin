namespace BlazingPizza.Server;

public static class SeedData
{
    public static void Initialize(PizzaStoreContext db)
    {
        var toppings = new Topping[]
        {
            new Topping()
            {
                    Name = "Dodatkowy ser",
                    Price = 3.5m,
            },
            new Topping()
            {
                    Name = "Bekon pieczony",
                    Price = 2.99m,
            },
            new Topping()
            {
                    Name = "Boczek",
                    Price = 2.99m,
            },
            new Topping()
            {
                    Name = "Bekon smażony",
                    Price = 2.99m,
            },
            new Topping()
            {
                    Name = "Smażony ser",
                    Price = 5.00m
            },
            new Topping()
            {
                    Name = "Bułeczki z pastą warzywną",
                    Price = 9.00m,
            },
            new Topping()
            {
                    Name = "Papryka",
                    Price = 1.00m,
            },
            new Topping()
            {
                    Name = "Cebula  ",
                    Price = 1.00m,
            },
            new Topping()
            {
                    Name = "Grzyby",
                    Price = 1.00m,
            },
            new Topping()
            {
                    Name = "Pepperoni",
                    Price = 1.00m,
            },
            new Topping()
            {
                    Name = "Salami",
                    Price = 3.50m,
            },
            new Topping()
            {
                    Name = "Mięso mielone",
                    Price = 2.50m,
            },
            new Topping()
            {
                    Name = "Podanie na srebrnym talerzu",
                    Price = 259.99m,
            },
            new Topping()
            {
                    Name = "Homar na pizzy",
                    Price = 95.90m,
            },
            new Topping()
            {
                    Name = "Kawior z jesiotra",
                    Price = 101.75m,
            },
            new Topping()
            {
                    Name = "Karczoch",
                    Price = 3.40m,
            },
            new Topping()
            {
                    Name = "Świeże pomidory",
                    Price = 1.50m,
            },
            new Topping()
            {
                    Name = "Bazylia",
                    Price = 1.50m,
            },
            new Topping()
            {
                    Name = "Steak (medium-rare)",
                    Price = 45.00m,
            },
            new Topping()
            {
                    Name = "Piekielnie ostra papryka",
                    Price = 4.50m,
            },
            new Topping()
            {
                    Name = "Kurczak pieczony",
                    Price = 5.00m,
            },
            new Topping()
            {
                    Name = "Ser pleśniowy",
                    Price = 2.50m,
            },
        };

        var specials = new PizzaSpecial[]
        {
            new PizzaSpecial()
            {
                    Name = "Serowa",
                    Description = "Serowa i klasyczna. Zawsze dobry wybór.",
                    BasePrice = 19.99m,
                    ImageUrl = "img/pizzas/cheese.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 2,
                    Name = "Królowa mięsa",
                    Description = "Zawiera każdy rodzaj bekonu",
                    BasePrice = 21.99m,
                    ImageUrl = "img/pizzas/bacon.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 3,
                    Name = "Klasyczne pepperoni",
                    Description = "Jak zwykłe pepperoni, ale ostra!",
                    BasePrice = 20.99m,
                    ImageUrl = "img/pizzas/pepperoni.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 4,
                    Name = "Buffalo chicken",
                    Description = "Pikantny kurczak, ostry sos i niebieski ser, rozgrzewająca od środka",
                    BasePrice = 25.90m,
                    ImageUrl = "img/pizzas/meaty.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 5,
                    Name = "Grzybowy specjał",
                    Description = "Pełna grzybów",
                    BasePrice = 21.00m,
                    ImageUrl = "img/pizzas/mushroom.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 6,
                    Name = "Polska",
                    Description = "Esencja tego, co polskie",
                    BasePrice = 24.99m,
                    ImageUrl = "img/pizzas/polska.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 7,
                    Name = "Wegetariański przysmak",
                    Description = "Po co kupować sałatkę jak można mieć sałatkę na pizzy",
                    BasePrice = 21.90m,
                    ImageUrl = "img/pizzas/salad.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 8,
                    Name = "Margherita",
                    Description = "Tradycyjna włoska pizza z serem, pomidorami i bazylią",
                    BasePrice = 16.99m,
                    ImageUrl = "img/pizzas/margherita.jpg",
            },
        };

        db.Toppings.AddRange(toppings);
        db.Specials.AddRange(specials);
        db.SaveChanges();
    }
}