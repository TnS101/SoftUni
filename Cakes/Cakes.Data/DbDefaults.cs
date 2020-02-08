using WebApplication1.Data.DbModels;
using WebApplication1.Data.Models;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DbDefaults
    {
        private static WebsiteDbContext Context = new WebsiteDbContext();
        public void Create()
        {
            Context.Database.EnsureCreated();
            //Customers
            var customer = new Customer
            {
                Name = "Pesho",
                Age = 16,
                Balance = 500,
            };
            Context.Customers.Add(customer);
            Context.ShoppingCarts.Add(new ShoppingCart
            {
                CustomerId = customer.Id
            });
            //Cakes
            Context.Cakes.Add(new Cake
            {
                Name = "Chocolate Cake",
                Price = 5
                ,
                Description = "Chocolate cake or chocolate gâteau (from French: gâteau au chocolat) is a cake flavored with melted chocolate, cocoa powder, or both."
            ,
                ImageURL = "https://spicysouthernkitchen.com/wp-content/uploads/Chocoholic-Cake-10.jpg"
            });

            Context.Cakes.Add(new Cake
            {
                Name = "Angel Food Cake",
                Price = 10
                ,
                Description = "Angel food cake, or angel cake, is a type of sponge cake made with egg whites, flour, and sugar. A whipping agent, such as cream of tartar, is commonly added. It differs from other cakes because it uses no butter. Its aerated texture comes from whipped egg white."
            ,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/42/Chocolate_angel_food_cake_with_various_toppings.jpg/1920px-Chocolate_angel_food_cake_with_various_toppings.jpg"
            });

            Context.Cakes.Add(new Cake
            {
                Name = "Butter Cake",
                Price = 15
                ,
                Description = "A butter cake is a cake in which one of the main ingredients is butter. Butter cake is baked with basic ingredients: butter, sugar, eggs, flour, and leavening agents such as baking powder or baking soda. It is considered as one of the quintessential cakes in American baking."
            ,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/182365_Gooey_Butter_Cake.jpg/1920px-182365_Gooey_Butter_Cake.jpg"
            });

            Context.Cakes.Add(new Cake
            {
                Name = "Pound Cake",
                Price = 20
                ,
                Description = "Pound cake is a type of cake traditionally made with a pound of each of four ingredients: flour, butter, eggs, and sugar. Pound cakes are generally baked in either a loaf pan or a Bundt mold, and served either dusted with powdered sugar, lightly glazed, or sometimes with a coat of icing."
                ,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/Almond_pound_cake%2C_angled_profile.jpg/1280px-Almond_pound_cake%2C_angled_profile.jpg"
            });

            Context.Cakes.Add(new Cake
            {
                Name = "Sponge Cake",
                Price = 30
                ,
                Description = "Sponge cake is a light cake made with eggs, flour and sugar, sometimes leavened with baking powder. Sponge cakes, leavened with beaten eggs, originated during the Renaissance, possibly in Spain",
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2d/Victoria_sponge.jpg/1920px-Victoria_sponge.jpg"
            });

            Context.Cakes.Add(new Cake
            {
                Name = "Chiffon Cake",
                Price = 40
                ,
                Description = "A chiffon cake is a very light cake made with vegetable oil, eggs, sugar, flour, baking powder, and flavorings.",
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2e/Meyer_lemon_chiffon_cake%2C_chocolate.jpg/1024px-Meyer_lemon_chiffon_cake%2C_chocolate.jpg"
            });

            Context.Cakes.Add(new Cake
            {
                Name = "Genoise",
                Price = 50
                ,
                Description = "A génoise , also known as Genoese cake or Genovese cake, is an Italian sponge cake named after the city of Genoa and associated with Italian and French cuisine. Instead of using chemical leavening, air is suspended in the batter during mixing to provide volume.",
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/e/e5/Pandispagna_cotto.JPG"
            });
            //Employees
            Context.Employees.Add(new Employee
            {
                Name = "Bobkata 6murda"
                ,
                Position = "Zubolekar"
                ,
                Salary = 1500
                ,
                ImageURL = "https://i.ibb.co/7z1WbK9/Boby-Shmurda.png"
            });

            Context.Employees.Add(new Employee
            {
                Name = "Golqmata Pompa",
                Position = "Vodoprovod4ik",
                Salary = 800
                ,
                ImageURL = "https://i.ibb.co/Jjkkywh/big-pump.png"
            });

            Context.Employees.Add(new Employee
            {
                Name = "Jey Zi",
                Position = "Gotva4",
                Salary = 2000
                ,
                ImageURL = "https://i.ibb.co/CWYygpD/jay-z.png"
            });

            Context.Employees.Add(new Employee
            {
                Name = "To6kata 69",
                Position = "Bonbonier",
                Salary = 600
                ,
                ImageURL = "https://i.ibb.co/jRSdLws/toshkata69.png"
            });
            Context.SaveChanges();

        }

        public void Delete()
        {
            Context.Database.EnsureDeleted();
        }
    }
}
