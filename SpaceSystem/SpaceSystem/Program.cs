using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SpaceSystemDB;
using SpaceSystemModels.PeopleModels;
using SpaceSystemModels.SpaceBodyModels;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SpaceSystem
{
    public class Program
    {
        private static string border = new string('*', 100);
        private static string separator = new string('-', 80);



        public static IConfigurationRoot _configuration;

        private static string _cnstr;
        private static DbContextOptionsBuilder _optionsBuilder;

        public static void Main(string[] args)
        {
            //create database
            //-------------------------------------------------------------------------------------------
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();

            _cnstr = Program._configuration["ConnectionStrings:SpaceSystemDB"];
            _optionsBuilder = new DbContextOptionsBuilder<SpaceSystemDBContext>().UseSqlServer(_cnstr);

            //display the menu
            //-------------------------------------------------------------------------------------------
            DisplayMenu();
        }

        private static int InputValidation(string s)
        {
            int result;
            //converting input string to int, if not corrent then will loop until user enter correctly
            //-------------------------------------------------------------------------------------------
            while (!Int32.TryParse(s, out result))
            {
                Console.WriteLine("Please enter in a number");
                s = StringValidation();
            }
            return result;
        }

        private static string StringValidation()
        {
            //checking user input
            //-------------------------------------------------------------------------------------------
            var input = Console.ReadLine();
            //making sure input is not empty and if it is have them reenter in input
            //-------------------------------------------------------------------------------------------
            while (input == string.Empty)
            {
                Console.WriteLine("You must enter in a valid input");
                input = Console.ReadLine();
            }
            return input;
        }

        private static void DisplayMenu()
        {

            Console.WriteLine("Welcome to Buy A Star");
            Console.WriteLine(border);
            Console.WriteLine();
            Console.WriteLine("Please choose your role:");
            Console.WriteLine("1: Employee");
            Console.WriteLine("2: Customer");
            var input = StringValidation();
            var result = InputValidation(input);
            //having user choose between employee and customer
            //-------------------------------------------------------------------------------------------
            switch (result)
            {
                case 1:
                    EmployeeLogin();
                    RunAgain();
                    break;
                case 2:
                    CustomerMenu();
                    RunAgain();
                    break;
                default:
                    Console.WriteLine("Please try again");
                    DisplayMenu();
                    break;
            }
        }

        //EMPLOYEE MENUS
        //*************************************************************************************************************************************************************************
        //*************************************************************************************************************************************************************************
        private static void EmployeeLogin()
        {
            Console.WriteLine(border);
            Console.WriteLine("Please enter in the Employee Id that you would like to access: [Enter in 0 to return]");
            var input = StringValidation();
            var employeeId = InputValidation(input);
            if (employeeId == 0) 
            {
                Console.WriteLine();
                DisplayMenu();
            }
            Console.WriteLine(separator);
            //accessing the database to get employee information
            //-------------------------------------------------------------------------------------------
            using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
            {
                //connecting program to database using employeeId
                //-------------------------------------------------------------------------------------------
                var e = context.Employees.SingleOrDefault(e => e.Id == employeeId);
                if (e.Id != null)
                {
                    Console.WriteLine("Please enter in your username");
                    var username = StringValidation();
                    Console.WriteLine("Please enter in your password");
                    var password = StringValidation();
                    //if the username or password is incorrect, prompt the user to try again
                    //-------------------------------------------------------------------------------------------
                    while (username != e.Username)
                    {
                        Console.WriteLine("Incorrect username, try again");
                        username = StringValidation();
                    }
                    while (password != e.Password)
                    {
                        Console.WriteLine("Incorrect password, try again");
                        password = StringValidation();
                    }
                }
                //fallback in case there is no employee or user reached here by mistake (not needed)
                //-------------------------------------------------------------------------------------------
                else
                {
                    DisplayMenu();
                }
            }
            EmployeeMenu();
        }

        private static void EmployeeMenu()
        {
            //getting employee selection
            //-------------------------------------------------------------------------------------------
            Console.WriteLine(border);
            Console.WriteLine($"Please make a selection:");
            Console.WriteLine();
            Console.WriteLine("1: Add an Employee");
            Console.WriteLine("2: Update an Employee");
            Console.WriteLine("3: Check Inventory");
            Console.WriteLine("4: Update Inventory");
            Console.WriteLine("5: Add Inventory");
            Console.WriteLine("6: Quit");
            var input = StringValidation();
            var result = InputValidation(input);
            //will choose where employee goes next based on input
            //-------------------------------------------------------------------------------------------
            switch (result)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    UpdateEmployee();
                    break;
                case 3:
                    CheckInventory();
                    break;
                case 4:
                    UpdateInventory();
                    break;
                case 5:
                    AddInventory();
                    break;
                case 6:
                    Console.WriteLine("Have a good day");
                    break;
                default:
                    Console.WriteLine("Please try again");
                    EmployeeMenu();
                    break;
            }
        }

        private static void AddEmployee()
        {
            //getting employee info
            //-------------------------------------------------------------------------------------------
            Console.WriteLine(border);
            Console.WriteLine("Please enter in employee information");
            Console.WriteLine("First Name: ");
            var firstName = StringValidation();
            Console.WriteLine("Last Name: ");
            var lastName = StringValidation();
            Console.WriteLine("Email: ");
            var email = StringValidation();
            Console.WriteLine("Username: ");
            var username = StringValidation();
            Console.WriteLine("Password: ");
            var password = StringValidation();
            Console.WriteLine("Confirm password: ");
            var confirmPassword = StringValidation();
            Console.WriteLine(separator);

            //checking in passwords match
            //-------------------------------------------------------------------------------------------
            while (password != confirmPassword)
            {
                Console.WriteLine("Passwords do not match, please try entering password in again");
                password = StringValidation();
                confirmPassword= StringValidation();
                Console.WriteLine(separator);
            }
            
            //making new employee
            //-------------------------------------------------------------------------------------------
            var newEmployee = new Employee();
            newEmployee.FirstName = firstName;
            newEmployee.LastName = lastName;
            newEmployee.Email = email;
            newEmployee.Username = username;
            newEmployee.Password = password;

            //checking to see if employee is already in database
            //-------------------------------------------------------------------------------------------
            using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
            {
                var e = context.Employees.SingleOrDefault(e => e.Username == newEmployee.Username);
                if (e != null)
                {
                    Console.WriteLine("Employee already exists, did you mean to update instead?");
                    Console.WriteLine("1: Yes");
                    Console.WriteLine("2: No, try again");
                    var input = StringValidation();
                    var result = InputValidation(input);
                    switch (result)
                    {
                        case 1:
                            UpdateEmployee();
                            break;
                        case 2:
                            AddEmployee();
                            break;
                        default:
                            Console.WriteLine("Going back to menu");
                            EmployeeMenu();
                            break;
                    }
                }

                //if not then add to database
                //-------------------------------------------------------------------------------------------
                else
                {
                    context.Employees.Add(newEmployee);
                    context.SaveChanges();
                }
            }
        }

        private static void UpdateEmployee()
        {
            //getting input to update employee
            //-------------------------------------------------------------------------------------------
            Console.WriteLine(border);
            Console.WriteLine("Please enter in Employee Id that you would like to update");
            var id = StringValidation();
            var employeeId = InputValidation(id);
            Console.WriteLine(separator);


            //accessing database to update whatever the user wanted
            //-------------------------------------------------------------------------------------------
            using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
            {
                var e = context.Employees.SingleOrDefault(e => e.Id == employeeId);
                if (e.Id != null)
                {
                    Console.WriteLine("Please enter in employee username");
                    var username = StringValidation();
                    Console.WriteLine("Please enter in employee password");
                    var password = StringValidation();
                    //if the username or password is incorrect, prompt the user to try again
                    //-------------------------------------------------------------------------------------------
                    while (username != e.Username)
                    {
                        Console.WriteLine("Incorrect username, try again");
                        username = StringValidation();
                    }
                    while (password != e.Password)
                    {
                        Console.WriteLine("Incorrect password, try again");
                        password = StringValidation();
                    }
                }
                Console.WriteLine();
                Console.WriteLine(separator);
                Console.WriteLine("What would you like to update on the employee?");
                Console.WriteLine("1: First Name");
                Console.WriteLine("2: Last Name");
                Console.WriteLine("3: Email");
                Console.WriteLine("4: Username");
                Console.WriteLine("5: Password");
                var input = StringValidation();
                var result = InputValidation(input);

                Console.WriteLine($"First Name: {e.FirstName} | Last Name: {e.LastName} | Email: {e.Email} | Username: {e.Username} | Password: {e.Password}");
                switch (result)
                {
                    case 1:
                        //update firstname
                        Console.WriteLine("Please enter in updated First Name:");
                        var firstName = StringValidation();
                        //update firstname in database
                        e.FirstName = firstName;
                        context.SaveChanges();
                        break;
                    case 2:
                        //update lastname
                        Console.WriteLine("Please enter in updated Last Name:");
                        var lastName = StringValidation();
                        //update lastname in database
                        e.LastName = lastName;
                        context.SaveChanges();
                        break;
                    case 3:
                        //update email
                        Console.WriteLine("Please enter in updated Email:");
                        var email = StringValidation();
                        //update email in database
                        e.Email = email;
                        context.SaveChanges();
                        break;
                    case 4:
                        //update username
                        Console.WriteLine("Please enter in updated Username:");
                        var username = StringValidation();
                        //update username in database
                        e.Username = username;
                        context.SaveChanges();
                        break;
                    case 5:
                        //update password
                        Console.WriteLine("Please enter in updated Password:");
                        var password = StringValidation();
                        //update password in database
                        e.Password = password;
                        context.SaveChanges();
                        break;
                    default:
                        Console.WriteLine("Please try again");
                        UpdateEmployee();
                        break;
                }
                
            }
        }

        private static void CheckInventory()
        {
            //getting input to select which dataset they would like to see
            //-------------------------------------------------------------------------------------------
            Console.WriteLine(border);
            Console.WriteLine("Would you like to look at Planets or Suns?");
            Console.WriteLine("1: Planets");
            Console.WriteLine("2: Suns");
            var input = StringValidation();
            var result = InputValidation(input);
            Console.WriteLine(separator);

            //accessing database to display the information that the user wants
            //-------------------------------------------------------------------------------------------
            using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
            {
                switch(result)
                {
                    case 1:
                        //getting all info from planet table and iterating
                        //-------------------------------------------------------------------------------------------
                        var p = context.Planets.FromSql($"SELECT * FROM dbo.Planets").ToList();
                        foreach (var planet in p)
                        {
                            if (planet.BoughtId == 0)
                            {
                                Console.OutputEncoding = System.Text.Encoding.Unicode;
                                Console.WriteLine($"{planet.Name} | Moons: {planet.Moons} | Days in Orbit: {planet.OrbitInDays} | Gravitational Pull (m/s{"²"}): {planet.GravitationalPull} | Not For Sale");
                            }
                            else if (planet.BoughtId == 1)
                            {
                                Console.OutputEncoding = System.Text.Encoding.Unicode;
                                Console.WriteLine($"{planet.Name} | Moons: {planet.Moons} | Days in Orbit: {planet.OrbitInDays} | Gravitational Pull (m/s{"²"}): {planet.GravitationalPull} | Currently For Sale");
                            }
                            else
                            {
                                Console.OutputEncoding = System.Text.Encoding.Unicode;
                                Console.WriteLine($"{planet.Name} | Moons: {planet.Moons} | Days in Orbit: {planet.OrbitInDays} | Gravitational Pull (m/s{"²"}): {planet.GravitationalPull} | Already Sold");
                            }
                        }
                        break;
                    case 2:
                        //getting all info from star table and iterating
                        //-------------------------------------------------------------------------------------------
                        var s = context.Stars.FromSql($"SELECT * FROM dbo.Stars").ToList();
                        foreach (var star in s)
                        {
                            if (star.BoughtId == 0)
                            {
                                Console.OutputEncoding = System.Text.Encoding.Unicode;
                                Console.WriteLine($"{star.Name} | Temperature(K): {star.Temperature} | Brightness(V): {star.Brightness} | Not For Sale");
                            }
                            else if (star.BoughtId == 1)
                            {
                                Console.OutputEncoding = System.Text.Encoding.Unicode;
                                Console.WriteLine($"{star.Name} | Temperature(K): {star.Temperature} | Brightness(V): {star.Brightness} | Currently For Sale");
                            }
                            else
                            {
                                Console.OutputEncoding = System.Text.Encoding.Unicode;
                                Console.WriteLine($"{star.Name} | Temperature(K): {star.Temperature} | Brightness(V): {star.Brightness} | Already Sold");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Please try again");
                        CheckInventory();
                        break;
                }
            }
        }

        private static void UpdateInventory()
        {
            //getting input to select which dataset they would like to update
            //-------------------------------------------------------------------------------------------
            Console.WriteLine(border);
            Console.WriteLine("Would you like to update the Planets or Suns?");
            Console.WriteLine("1: Planets");
            Console.WriteLine("2: Suns");
            var input = StringValidation();
            var result = InputValidation(input);
            Console.WriteLine(separator);

            //accessing database to display the information that the user wants
            //-------------------------------------------------------------------------------------------
            using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
            {
                switch (result)
                {
                    case 1:
                        //getting which planet they want to update
                        //-------------------------------------------------------------------------------------------
                        Console.WriteLine("Please enter in Planet Id that you would like to update");
                        var id = StringValidation();
                        var planetId = InputValidation(id);

                        //showing current data of planet
                        //-------------------------------------------------------------------------------------------
                        var p = context.Planets.SingleOrDefault(p => p.Id == planetId);
                        if (p.BoughtId == 2)
                        {
                            Console.WriteLine("Planet already purchased, cannot update");
                            Console.WriteLine("Going back to the Employee Menu");
                            EmployeeMenu();
                        }
                        Console.WriteLine("Sale Id 1: Not For Sale");
                        Console.WriteLine("Sale Id 2: Currently For Sale");
                        Console.WriteLine("Sale Id 3: Already Sold");
                        Console.WriteLine($"{p.Name} | Moons: {p.Moons} | Days in Orbit: {p.OrbitInDays} | Gravitational Pull (m/s{"²"}): {p.GravitationalPull} | Sale Id: {p.BoughtId}");

                        //checking what they want to update
                        //-------------------------------------------------------------------------------------------
                        Console.WriteLine("What would you like to update?");
                        Console.WriteLine("1: Name");
                        Console.WriteLine("2: Moons");
                        Console.WriteLine("3: Days in Orbit");
                        Console.WriteLine("4: Gravitational Pull");
                        Console.WriteLine("5: Sale Category");
                        var updateRequest = StringValidation();
                        var update = InputValidation(updateRequest);
                        Console.WriteLine(separator);

                        switch(update)
                        {
                            case 1:
                                Console.WriteLine("Please enter in updated Name:");
                                var updatedName = StringValidation();
                                //update name in database
                                p.Name = updatedName;
                                context.SaveChanges();
                                break;
                            case 2:
                                Console.WriteLine("Please enter in updated Moon Count");
                                var moonUpdate = StringValidation();
                                var countUpadate = InputValidation(moonUpdate);
                                //update moon count in database
                                p.Moons = countUpadate;
                                context.SaveChanges();
                                break;
                            case 3:
                                Console.WriteLine("Please enter in updated Orbit Length in Days");
                                var daysUpdate = StringValidation();
                                var orbitUpadate = InputValidation(daysUpdate);
                                //update moon count in database
                                p.OrbitInDays = orbitUpadate;
                                context.SaveChanges();
                                break;
                            case 4:
                                Console.WriteLine("Please enter in the updated Gravitational Pull to 2 decimal places");
                                var numberChange = StringValidation();
                                decimal newDecimal;
                                while (!Decimal.TryParse(numberChange, out newDecimal))
                                {
                                    Console.WriteLine("Please enter in a decimal");
                                    numberChange = StringValidation();
                                }
                                var gravitationalUpdate = newDecimal;
                                //update gravitational pull in database
                                p.GravitationalPull = gravitationalUpdate;
                                context.SaveChanges();
                                break;
                            case 5:
                                Console.WriteLine("Please enter in the updated sale category");
                                Console.WriteLine("Sale Id 1: Not For Sale");
                                Console.WriteLine("Sale Id 2: Currently For Sale");
                                Console.WriteLine("Sale Id 3: Already Sold");
                                var saleId = StringValidation();
                                var updatedSaleId = InputValidation(saleId);
                                //update bought id in database
                                p.BoughtId= updatedSaleId;
                                context.SaveChanges();
                                break;
                            default:
                                Console.WriteLine("Going back to inventory menu");
                                UpdateInventory();
                                break;
                        }
                        break;
                    case 2:
                        //getting which star they want to update
                        //-------------------------------------------------------------------------------------------
                        Console.WriteLine("Please enter in Star Id that you would like to update");
                        var sid = StringValidation();
                        var starId = InputValidation(sid);

                        //showing current data of planet
                        //-------------------------------------------------------------------------------------------
                        var s = context.Stars.SingleOrDefault(s => s.Id == starId);
                        Console.WriteLine("Sale Id 1: Not For Sale");
                        Console.WriteLine("Sale Id 2: Currently For Sale");
                        Console.WriteLine("Sale Id 3: Already Sold");
                        Console.WriteLine($"{s.Name} | Temperature(K): {s.Temperature} | Brightness(V): {s.Brightness} | Sale Id: {s.BoughtId}");

                        //checking what they want to update
                        //-------------------------------------------------------------------------------------------
                        Console.WriteLine("What would you like to update?");
                        Console.WriteLine("1: Name");
                        Console.WriteLine("2: Temperature");
                        Console.WriteLine("3: Brightness");
                        Console.WriteLine("4: Sale Category");
                        var supdateRequest = StringValidation();
                        var supdate = InputValidation(supdateRequest);
                        Console.WriteLine(separator);

                        switch (supdate)
                        {
                            case 1:
                                Console.WriteLine("Please enter in updated Name:");
                                var supdatedName = StringValidation();
                                //update name in database
                                s.Name = supdatedName;
                                context.SaveChanges();
                                break;
                            case 2:
                                Console.WriteLine("Please enter in the updated Temperature");
                                var updatedTemp = StringValidation();
                                var newTemp = InputValidation(updatedTemp);
                                //update temperature in database
                                s.Temperature = newTemp;
                                context.SaveChanges();
                                break;
                            case 3:
                                Console.WriteLine("Please enter in the updated Brightness");
                                var decimalUpdate = StringValidation();
                                decimal decimalResult;
                                while (!Decimal.TryParse(decimalUpdate, out decimalResult))
                                {
                                    Console.WriteLine("Please enter in a decimal");
                                    decimalUpdate = StringValidation();
                                }
                                var brightnessUpdate = decimalResult;
                                //update brightness in database
                                s.Brightness = brightnessUpdate;
                                context.SaveChanges();
                                break;
                            case 4:
                                Console.WriteLine("Please enter in the updated sale category");
                                Console.WriteLine("Sale Id 1: Not For Sale");
                                Console.WriteLine("Sale Id 2: Currently For Sale");
                                Console.WriteLine("Sale Id 3: Already Sold");
                                var newSaleId = StringValidation();
                                var updateSaleCategory = InputValidation(newSaleId);
                                //update bought id in database
                                s.BoughtId = updateSaleCategory;
                                context.SaveChanges();
                                break;
                            default:
                                Console.WriteLine("Going back to inventory menu");
                                UpdateInventory();
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Please try again");
                        UpdateInventory();
                        break;
                }
            }
        }

        private static void AddInventory()
        {
            //checking to see if add planet or star
            //-------------------------------------------------------------------------------------------

            Console.WriteLine(border);
            Console.WriteLine("Would you like to add a Planet or Star?");
            Console.WriteLine("1: Planet");
            Console.WriteLine("2: Star");
            var input = StringValidation();
            var result = InputValidation(input);
            Console.WriteLine(separator);
            switch (result)
            {
                case 1:
                    //getting info on planet
                    //-------------------------------------------------------------------------------------------
                    Console.WriteLine("Please enter in Planet Name");
                    var name = StringValidation();
                    Console.WriteLine("Please enter in amount of Moons");
                    var moonAmount = StringValidation();
                    var moons = InputValidation(moonAmount);
                    Console.WriteLine("Please enter in the Orbit in Days");
                    var orbitAmount = StringValidation();
                    var orbit = InputValidation(orbitAmount);
                    Console.WriteLine("Please enter in the Gravitational Pull of the planet");
                    var decimalChange = StringValidation();
                    decimal newDecimal;
                    while (!Decimal.TryParse(decimalChange, out newDecimal))
                    {
                        Console.WriteLine("Please enter in a decimal");
                        decimalChange = StringValidation();
                    }
                    var gravitationalPull = newDecimal;
                    Console.WriteLine(separator);

                    //making new planet
                    //-------------------------------------------------------------------------------------------
                    var newPlanet = new Planet();
                    newPlanet.Name = name;
                    newPlanet.Moons = moons;
                    newPlanet.OrbitInDays= orbit;
                    newPlanet.GravitationalPull = gravitationalPull;
                    newPlanet.BoughtId = 1;

                    //checking to see if planet is already in database
                    //-------------------------------------------------------------------------------------------
                    using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
                    {
                        var p = context.Planets.SingleOrDefault(p => p.Name == newPlanet.Name);
                        if (p != null)
                        {
                            Console.WriteLine("Planet already exists, did you mean to update instead?");
                            Console.WriteLine("1: Yes");
                            Console.WriteLine("2: No, go back to menu");
                            var choice = StringValidation();
                            var path = InputValidation(input);
                            switch (path)
                            {
                                case 1:
                                    UpdateInventory();
                                    break;
                                case 2:
                                    EmployeeMenu();
                                    break;
                                default:
                                    Console.WriteLine("Going back to inventory menu");
                                    UpdateInventory();
                                    break;
                            }
                        }

                        //if not then add to database
                        //-------------------------------------------------------------------------------------------
                        else
                        {
                            context.Planets.Add(newPlanet);
                            context.SaveChanges();
                        }
                    }
                    break;
                case 2:
                    //getting info on planet
                    //-------------------------------------------------------------------------------------------
                    Console.WriteLine("Please enter in Star Name");
                    var sName = StringValidation();
                    Console.WriteLine("Please enter in Temperature");
                    var tempAmount = StringValidation();
                    var temperature = InputValidation(tempAmount);
                    Console.WriteLine("Please enter in the Brightness");
                    var brightnessAmount = StringValidation();
                    decimal newBrightness;
                    while (!Decimal.TryParse(brightnessAmount, out newBrightness))
                    {
                        Console.WriteLine("Please enter in a decimal");
                        brightnessAmount = StringValidation();
                    }
                    var brightness = newBrightness;
                    Console.WriteLine(separator);

                    //making new star
                    //-------------------------------------------------------------------------------------------
                    var newStar = new Star();
                    newStar.Name = sName;
                    newStar.Temperature = temperature;
                    newStar.Brightness = brightness;
                    newStar.BoughtId = 1;

                    //checking to see if planet is already in database
                    //-------------------------------------------------------------------------------------------
                    using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
                    {
                        var s = context.Stars.SingleOrDefault(s => s.Name == newStar.Name);
                        if (newStar.BoughtId == 2)
                        {
                            Console.WriteLine("Star already purchased, cannot update");
                            Console.WriteLine("Going back to the Employee Menu");
                            EmployeeMenu();
                        }
                        if (s != null)
                        {
                            Console.WriteLine("Star already exists, did you mean to update instead?");
                            Console.WriteLine("1: Yes");
                            Console.WriteLine("2: No, go back to menu");
                            var choice = StringValidation();
                            var path = InputValidation(input);
                            switch (path)
                            {
                                case 1:
                                    UpdateInventory();
                                    break;
                                case 2:
                                    EmployeeMenu();
                                    break;
                                default:
                                    Console.WriteLine("Going back to inventory menu");
                                    UpdateInventory();
                                    break;
                            }
                        }

                        //if not then add to database
                        //-------------------------------------------------------------------------------------------
                        else
                        {
                            context.Stars.Add(newStar);
                            context.SaveChanges();
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Please try again");
                    AddInventory();
                    break;
            }
        }

        //CUSTOMER MENUS
        //*************************************************************************************************************************************************************************
        //*************************************************************************************************************************************************************************

        private static void CustomerMenu()
        {
            //getting customer selection
            //-------------------------------------------------------------------------------------------
            Console.WriteLine(border);
            Console.WriteLine($"Please make a selection:");

            Console.WriteLine();
            Console.WriteLine("1: Buy A Planet");
            Console.WriteLine("2: Buy A Star");
            Console.WriteLine("3: Add New Customer");
            Console.WriteLine("4: Check Previous Purchases");
            Console.WriteLine("5: Return Purchase");
            Console.WriteLine("6: Quit");
            var input = StringValidation();
            var result = InputValidation(input);
            //will choose where customer goes next based on input
            //-------------------------------------------------------------------------------------------
            switch (result)
            {
                case 1:
                   BuyPlanet();
                    break;
                case 2:
                    BuyStar();
                    break;
                case 3:
                    CreateCustomer();
                    break;
                case 4:
                    CheckPreviousPurchases();
                    break;
                case 5:
                    ReturnPurchase();
                    break;
                case 6:
                    Console.WriteLine("Have a good day");
                    break;
                default:
                    Console.WriteLine("Please try again");
                    CustomerMenu();
                    break;
            }
        }

        private static void BuyPlanet()
        {
            Console.WriteLine(border);
            //show current planets for sale
            //-------------------------------------------------------------------------------------------
            using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
            {
                var p = context.Planets.FromSql($"SELECT * FROM dbo.Planets").ToList();
                foreach (var planet in p)
                {
                    if (planet.BoughtId == 1)
                    {
                        Console.OutputEncoding = System.Text.Encoding.Unicode;
                        Console.WriteLine($"{planet.Name} | Moons: {planet.Moons} | Days in Orbit: {planet.OrbitInDays} | Gravitational Pull (m/s{"²"}): {planet.GravitationalPull} | Currently For Sale");
                    }
                }
                //checking to see which planet user wants to buy
                //-------------------------------------------------------------------------------------------
                Console.WriteLine(separator);
                Console.WriteLine("Which planet would you like to buy?");
                Console.WriteLine("Enter in the planet name");
                var planetName = StringValidation();
                Console.WriteLine($"Is {planetName} the correct planet you want to buy?");
                Console.WriteLine("1: Yes");
                Console.WriteLine("2: No");
                var input = StringValidation();
                var result = InputValidation(input);

                switch(result)
                {
                    //logging customer in to complete order
                    //-------------------------------------------------------------------------------------------
                    case 1:
                        Console.WriteLine(separator);
                        Console.WriteLine("Please log in to complete order");
                        var customerId = CustomerLogin();
                        var customer = context.Customers.SingleOrDefault(c => c.Id == customerId);
                        var planet = context.Planets.SingleOrDefault(p => p.Name == planetName);

                        planet.BoughtId = 2;
                        planet.CustomerId = customerId;
                        Console.WriteLine($"You have purchased {planet.Name}");
                        customer.Planets.Add(planet);
                        context.SaveChanges();
                        break;
                    case 2:
                        Console.WriteLine("Trying again");
                        BuyPlanet();
                        break;
                    default:
                        Console.WriteLine("Please try again");
                        BuyPlanet();
                        break;
                }
            }
        }

        private static void BuyStar()
        {
            Console.WriteLine(border);
            //show current stars for sale
            //-------------------------------------------------------------------------------------------
            using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
            {
                var s = context.Stars.FromSql($"SELECT * FROM dbo.Stars").ToList();
                foreach (var star in s)
                {
                    if (star.BoughtId == 1)
                    {
                        Console.WriteLine($"{star.Name} | Temperature(K): {star.Temperature} | Brightness(V): {star.Brightness} | Currently For Sale");
                    }
                }
                //checking to see which star user wants to buy
                //-------------------------------------------------------------------------------------------
                Console.WriteLine(separator);
                Console.WriteLine("Which star would you like to buy?");
                Console.WriteLine("Enter in the star name");
                var starName = StringValidation();
                Console.WriteLine($"Is {starName} the correct star you want to buy?");
                Console.WriteLine("1: Yes");
                Console.WriteLine("2: No");
                var input = StringValidation();
                var result = InputValidation(input);

                switch (result)
                {
                    //logging customer in to complete order
                    //-------------------------------------------------------------------------------------------
                    case 1:
                        Console.WriteLine(separator);
                        Console.WriteLine("Please log in to complete order");
                        var customerId = CustomerLogin();
                        var customer = context.Customers.SingleOrDefault(c => c.Id == customerId);
                        var star = context.Stars.SingleOrDefault(p => p.Name == starName);

                        star.BoughtId = 2;
                        star.CustomerId = customerId;
                        Console.WriteLine($"You have purchased {star.Name}");
                        customer.Stars.Add(star);
                        context.SaveChanges();
                        break;
                    case 2:
                        Console.WriteLine("Trying again");
                        BuyStar();
                        break;
                    default:
                        Console.WriteLine("Please try again");
                        BuyStar();
                        break;
                }
            }
        }

        private static void CreateCustomer()
        {
            //getting customer info
            //-------------------------------------------------------------------------------------------
            Console.WriteLine(border);
            Console.WriteLine("Please enter in your information");
            Console.WriteLine("First Name: ");
            var firstName = StringValidation();
            Console.WriteLine("Middle Name: [Enter 0 if no middle name]");
            var middleName = StringValidation();
            Console.WriteLine("Last Name: ");
            var lastName = StringValidation();
            Console.WriteLine("Email: ");
            var email = StringValidation();
            Console.WriteLine("Username: ");
            var username = StringValidation();
            Console.WriteLine("Street Address: ");
            var streetAddress = StringValidation();
            Console.WriteLine("City: ");
            var city = StringValidation();
            Console.WriteLine("Country: ");
            var country = StringValidation();
            Console.WriteLine("Phone Number: ");
            var input = StringValidation();
            var phone = InputValidation(input);
            Console.WriteLine(separator);

            //making new customer
            //-------------------------------------------------------------------------------------------
            var newCustomer = new Customer();
            newCustomer.FirstName = firstName;
            if (middleName == "0")
            {
                newCustomer.MiddleName = null;
            }
            newCustomer.MiddleName = middleName;
            newCustomer.LastName = lastName;
            newCustomer.Email = email;
            newCustomer.Username = username;
            newCustomer.Street = streetAddress;
            newCustomer.City = city;
            newCustomer.Country = country;
            newCustomer.Phone = phone;

            //checking to see if customer is already in database
            //-------------------------------------------------------------------------------------------
            using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
            {
                var c = context.Customers.SingleOrDefault(c => c.Username == newCustomer.Username);
                if (c != null)
                {
                    Console.WriteLine("Customer already exists, cannot add");
                    Console.WriteLine("Would you like to go back to the Customer Menu?");
                    Console.WriteLine("1: Yes");
                    Console.WriteLine("2: No, quit");
                    var choice = StringValidation();
                    var result = InputValidation(choice);
                    switch (result)
                    {
                        case 1:
                            CustomerMenu();
                            break;
                        case 2:
                            Console.WriteLine("Have a good day :)");
                            break;
                        default:
                            Console.WriteLine("Please try again");
                            CreateCustomer();
                            break;
                    }
                }

                //if not then add to database
                //-------------------------------------------------------------------------------------------
                else
                {
                    context.Customers.Add(newCustomer);
                    context.SaveChanges();
                }
            }
        }

        private static void CheckPreviousPurchases()
        {
            //logging customer in
            //-------------------------------------------------------------------------------------------
            Console.WriteLine(border);
            Console.WriteLine("Please login to review purchases");
            var customerId = CustomerLogin();
            //accessing database to get customer data
            //-------------------------------------------------------------------------------------------
            Console.WriteLine(separator);
            using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
            {
                //getting planet and star data using customer info
                //-------------------------------------------------------------------------------------------
                var planets = context.Planets.FromSql($"SELECT * FROM dbo.Planets WHERE CustomerId = customerId").ToList();
                var stars = context.Stars.FromSql($"SELECT * FROM dbo.Stars WHERE CustomerId = customerId").ToList();
                Console.WriteLine("Planets:");
                foreach (var p in planets)
                {
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    Console.WriteLine($"{p.Name} | Moons: {p.Moons} | Days in Orbit: {p.OrbitInDays} | Gravitational Pull (m/s{"²"}): {p.GravitationalPull}");
                }
                Console.WriteLine(separator);
                Console.WriteLine("Stars:");
                foreach (var s in stars)
                {
                    Console.WriteLine($"{s.Name} | Temperature(K): {s.Temperature} | Brightness(V): {s.Brightness}");
                }
            }
        }

        private static void ReturnPurchase()
        {
            //logigng in customer
            //-------------------------------------------------------------------------------------------
            Console.WriteLine(border);
            Console.WriteLine("Please loging to return purchase");
            var customerId = CustomerLogin();

            //getting user choice to see what they would like to return
            //-------------------------------------------------------------------------------------------
            Console.WriteLine(separator);
            Console.WriteLine("Would you like to return a Planet or Star?");
            Console.WriteLine("1: Planet");
            Console.WriteLine("2: Star");
            var input = StringValidation();
            var result = InputValidation(input);
            Console.WriteLine(separator);

            using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
            {
                switch (result)
                {
                    case 1:
                        //seeing what planet they want to return
                        //-------------------------------------------------------------------------------------------
                        var planets = context.Planets.FromSql($"SELECT * FROM dbo.Planets WHERE CustomerId = customerId").ToList();
                        foreach (var planet in planets)
                        {
                            Console.OutputEncoding = System.Text.Encoding.Unicode;
                            Console.WriteLine($"{planet.Name} | Moons: {planet.Moons} | Days in Orbit: {planet.OrbitInDays} | Gravitational Pull (m/s{"²"}): {planet.GravitationalPull} | Currently For Sale");
                        }
                        Console.WriteLine(separator);
                        Console.WriteLine("Which planet would you like to return?");
                        Console.WriteLine("Enter in the planet name");
                        var planetName = StringValidation();
                        Console.WriteLine($"Is {planetName} the correct planet you want to return?");
                        Console.WriteLine("1: Yes");
                        Console.WriteLine("2: No");
                        var nameChoice = StringValidation();
                        var name = InputValidation(nameChoice);

                        switch (name)
                        {
                            case 1:
                                Console.WriteLine(separator);
                                var customer = context.Customers.SingleOrDefault(c => c.Id == customerId);
                                var planet = context.Planets.SingleOrDefault(p => p.Name == planetName);

                                planet.BoughtId = 1;
                                planet.CustomerId = null;
                                Console.WriteLine($"You have returned {planet.Name}");
                                customer.Planets.Remove(planet);
                                context.SaveChanges();
                                break;
                            case 2:
                                Console.WriteLine("Try again");
                                nameChoice= Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Try again");
                                ReturnPurchase();
                                break;
                        }
                        break;
                    case 2:
                        //seeing what star they want to return
                        //-------------------------------------------------------------------------------------------
                        var stars = context.Stars.FromSql($"SELECT * FROM dbo.Stars WHERE CustomerId = customerId").ToList();
                        foreach (var star in stars)
                        {
                            Console.WriteLine($"{star.Name} | Temperature(K): {star.Temperature} | Brightness(V): {star.Brightness}");
                        }
                        Console.WriteLine(separator);
                        Console.WriteLine("Which star would you like to return?");
                        Console.WriteLine("Enter in the star name");
                        var starName = StringValidation();
                        Console.WriteLine($"Is {starName} the correct planet you want to return?");
                        Console.WriteLine("1: Yes");
                        Console.WriteLine("2: No");
                        var yesno = StringValidation();
                        var choice = InputValidation(yesno);

                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine(separator);
                                var customer = context.Customers.SingleOrDefault(c => c.Id == customerId);
                                var star = context.Stars.SingleOrDefault(s => s.Name == starName);

                                star.BoughtId = 1;
                                star.CustomerId = null;
                                Console.WriteLine($"You have returned {star.Name}");
                                customer.Stars.Remove(star);
                                context.SaveChanges();
                                break;
                            case 2:
                                Console.WriteLine("Try again");
                                nameChoice = Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Try again");
                                ReturnPurchase();
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Try again");
                        ReturnPurchase();
                        break;
                }
            }
        }

        private static int CustomerLogin()
        {
            Console.WriteLine("Please enter in the Customer First and Last Name that you would like to access: [Enter in 0 to return]");
            Console.WriteLine("First Name:");
            var firstName = StringValidation();
            if (firstName == "0")
            {
                Console.WriteLine();
                DisplayMenu();
            }
            Console.WriteLine("Last Name:");
            var lastName = StringValidation();
            Console.WriteLine(separator);
            //accessing the database to get customer information
            //-------------------------------------------------------------------------------------------
            using (var context = new SpaceSystemDBContext(_optionsBuilder.Options))
            {
                //connecting program to database using employeeId
                //-------------------------------------------------------------------------------------------
                var c = context.Customers.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
                if (c.FirstName != null && c.LastName != null)
                {
                    Console.WriteLine("Please enter in your username");
                    var username = StringValidation();
                    while (username != c.Username)
                    {
                        Console.WriteLine("Incorrect username, try again");
                        username = StringValidation();
                    }

                    Console.WriteLine($"You have logged in as {c.FirstName}");
                }
                //fallback in case there is no customer or user reached here by mistake (not needed)
                //-------------------------------------------------------------------------------------------
                else
                {
                    DisplayMenu();
                }
                return c.Id;
            }
        }

        private static void RunAgain()
        {
            Console.WriteLine(border);
            Console.WriteLine($"Would you like to run again?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");
            var input = StringValidation();
            var choice = InputValidation(input);

            switch (choice)
            {
                case 1:
                    DisplayMenu();
                    break;
                case 2:
                    Console.WriteLine("Have a good day!");
                    break;
                default:
                    Console.WriteLine("Try again");
                    RunAgain();
                    break;
            }
        }
    }
}