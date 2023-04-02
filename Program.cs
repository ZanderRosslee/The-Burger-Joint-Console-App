using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    class Program
    {
        // Variable for color change for frames methods
        private static string color = "red";

        // Diffrent menu's for each catagory
        enum Menu
        {
            Specials = 1,
            Comobos,
            Hamburger,
            Sides,
            Soda,
            Suprise,
            Receipt
        }

        enum Specials
        {
        Delux =1,
        Monster,
        Munch,
        Back
        }

        enum Combos
        {
        Green=1,
        Double,
        Friends,
        Family,
        Back
        }

        enum Hamburger
        {
            Cheese = 1,
            Beef,
            Rib,
            Vegie,
            Stack,
            Back
        }

        enum Sides
        {
            Chips = 1,
            Onion,
            Salad,
            Potato,
            Back
        }

        enum Beverages
        {
        Juice =1,
        Soda,
        Milkshakes,
        Boba,
        Coffee,
        Choclate,
        Back
        }

        enum Suprise
        {
        Agree=1,
        Back
        }

        enum Payslip
        {
            Pay = 1,
            Back
        }

        // Main scope cotaining all methods for display and calculations
        static void Main(string[] args)
        {
            int option = 0;
            bool login;

            List<String> Receipt = new List<string>();
            List<double> Total = new List<double>();

            login = Login();

            while (login==true)
            {
                Home();
                Console.WriteLine("Please choose an option");
                option = int.Parse(Console.ReadLine());

                switch ((Menu)option)
                {
                    case Menu.Specials:
                        Special(Receipt, Total);
                        break;
                    case Menu.Comobos:
                        Combo(Receipt, Total);
                        break;
                    case Menu.Hamburger:
                        Hamburgers(Receipt,Total);
                        break;
                    case Menu.Sides:
                        Side(Receipt, Total);
                        break;
                    case Menu.Soda:
                        Drinks(Receipt, Total);
                        break;
                    case Menu.Suprise:
                        SupriseMe(Receipt, Total);
                        break;
                    case Menu.Receipt:
                        PayList(Receipt,Total);  
                        break;
                    default:
                        Console.WriteLine("Enter a correct option");
                        break;
                }
            }
            Console.ReadLine();
        }


        // Home Scope for displaying home screen
        static void Home ()
        {
            Console.Clear();
            FirstLine();
            SpecialRow("THE BURGER JOINT");
            string line;
            Console.ForegroundColor = ConsoleColor.Red;
            line = "╠" + new string('═', 73) + "╣";
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
            SpecialRow("1. Specials");
            SpecialRow("2. Comobo's");
            SpecialRow("3. Hamburger");
            SpecialRow("4. Sides");
            SpecialRow("5. Beverages");
            SpecialRow("6. SUPRISE ME");
            SpecialRow("7. Receipt");
            LastLine();
        }

        // Recceipt Scope for displaying the receipt and totals and handels payments
        static void PayList (List<String>Items, List<double>Prices)
        {

            Console.Clear();
            int option = 0;
            int payoption = 0;
            string exit;
            string card;
            DateTime dt = DateTime.Now;

            FirstLine();
            SpecialRow("YOUR ORDER IS");
            LastLine();

            Console.WriteLine();

            string[,] receipt = new string[Items.Count,2];

            for (int r = 0; r < Items.Count; r++)
            {
                receipt[r,0] = Items[r];
            }

            for (int r = 0; r < Prices.Count; r++)
            {
                receipt[r, 1] = Prices[r].ToString();
            }
            
            color = "green";
            Console.ForegroundColor = ConsoleColor.Green;
            string line;
            line = "╔" + new string('═', 36) + "╦" + new string('═', 36) + "╗";
            Console.WriteLine(line);
            Row("Item","Price");
            line = "╠" + new string('═', 36) + "╬" + new string('═', 36) + "╣";
            Console.WriteLine(line);

            for (int r = 0; r < receipt.GetLength(0); r++)
            {
                Row(receipt[r, 0], "R "+receipt[r, 1]);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            line = "╚" + new string('═', 36) + "╩" + new string('═', 36) + "╝";

            Console.WriteLine(line);
            Console.WriteLine(Environment.NewLine+"The total is R" + Prices.Sum());
            Console.WriteLine("The total items purchased are: "+ receipt.GetLength(0));

            color = "red";
            FirstLine();

            if (Items.Count > 0)
            {
                Row("1. Pay", "2. Back");

                LastLine();

                Console.WriteLine("Please choose an option");
                option = int.Parse(Console.ReadLine());

                switch ((Payslip)option)
                {
                    case Payslip.Pay:
                        Console.WriteLine("Payment method:");
                        Console.WriteLine("1. Credit payment");
                        Console.WriteLine("2. Debit payment");
                        Console.WriteLine("3. Crypto payment");
                        Console.WriteLine("Please enter an option");

                        payoption = int.Parse(Console.ReadLine());

                        while (payoption == 0 || payoption>3)
                        {
                            Console.WriteLine("Please enter a correct option");
                            payoption = int.Parse(Console.ReadLine());
                        }
                      
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("You have succesufully paid!");
                            Console.WriteLine(dt);
                            Items.Clear();
                            Prices.Clear();
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            Console.WriteLine("Do you want to exit the application? (Y / N)");
                            exit = Console.ReadLine();

                            if (exit.ToUpper() == "Y")
                            {
                                System.Environment.Exit(0);
                            }
                            else
                            {
                                break;
                            }
                        break;
                      
                    case Payslip.Back:
                        return;
                        break;
                    default:
                        Console.WriteLine("Enter a correct option");
                        break;
                }
            }
            else
            {
                SpecialRow("Press any number to go back");

                LastLine();

                Console.WriteLine("Please choose an option");
                option = int.Parse(Console.ReadLine());
                return;
            }
        }

        // FirstLine Scope for top frame line 
        static void FirstLine()
        {
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            string line;
            line = "╔" + new string('═', 73) + "╗";
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // SecondLine Scope for line frame uder sub headings
        static void SecondLine ()
        {
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            string line;

            line= "╠" + new string('═', 36)+ "╦"+ new string('═', 36)+"╣";
           
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // ThirdLine Scope for first middle frame line
        static void ThirdLine()
        {
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            string line;

            line = "╠" + new string('═', 36) + "╬" + new string('═', 36) + "╣";


            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // ForthLine Scope for second middle frame line
        static void ForthLine()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string line;

            line = "╠" + new string('═', 36) + "╩" + new string('═', 36) + "╣";


            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // LastLine Scope for bottom frame line 
        static void LastLine()
        {
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            string line;
            line = "╚" + new string('═', 73) + "╝";
          
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Row Scope for inserting row frame left, right and center 
        static void Row(params string[] columns)
        {
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            
            int width = (75 - columns.Length) / columns.Length;
            Console.Write("║");
            string row = "";
            


            foreach (string column in columns)
            {
                Console.ForegroundColor = ConsoleColor.White;
                row += CenterAlign(column, width);
                Console.Write(row);
                if (color == "red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.Write("║");
                row = "";
            }

            Console.Write("\n");
        }

        // SpecialRow Scope for inserting one row frame left and right
        static void SpecialRow(params string[] columns)
        {
            int width = (75 - columns.Length) / columns.Length-2;
            Console.ForegroundColor = ConsoleColor.Red;
            string row = "║";


            foreach (string column in columns)
            {
                row += CenterAlign(column, width) + " ║";
            }

            Console.WriteLine(row);
            Console.ForegroundColor = ConsoleColor.White;

        }

        // CenterAlign Scope for aligning all text in rows in the middle
        static string CenterAlign(string text, int width)
        {
            if (text.Length > width)
            {
                text = text.Substring(0, width - 3) + "...";
            } else 
            {
                text = text;
            }

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        // Special Scope for displaying and purchasing Special items and adds them to lists for prices and items
        static void Special(List<String> Items, List<double> prices)
        {
            int option = 0;
            bool order = true;

            while (order)
            {
                Console.Clear();
                FirstLine();
                SpecialRow("Specials");
                SecondLine();
                Row("Items", "Price");
                ThirdLine();
                Row("1. Delux Meal:", "R100");
                Row("Thick and Stick Rib Burger","");
                Row("Three Sides", "");
                ThirdLine();
                Row("2. Monster Meal:", "R90");
                Row("Thick and Stick Rib Burger","");
                Row("Double Stacked That's That Burger", "");
                ThirdLine();
                Row("3. Munch Crunch Meal:", "R80");
                Row("Double Stacked That's That Burger","");
                Row("One Side", "");
                ForthLine();
                SpecialRow("4. Back");
                LastLine();

                Console.WriteLine(Environment.NewLine + "Please choose an option");
                option = int.Parse(Console.ReadLine());

                switch ((Specials)option)
                {
                    case Specials.Delux:
                        Items.Add("Delux Meal");
                        prices.Add(100);
                        break;
                    case Specials.Monster:
                        Items.Add("Monster Meal");
                        prices.Add(90);
                        break;
                    case Specials.Munch:
                        Items.Add("Munch Crunch Meal");
                        prices.Add(80);
                        break;
                    case Specials.Back:
                        return;
                        break;
                    default:
                        Console.WriteLine("Enter a correct option");
                        break;
                }
            }
            Console.ReadLine();
        }

        // Combo Scope for displaying and purchasing Combo items and adds them to lists for prices and items
        static void Combo(List<String> Items, List<double> prices)
        {
            int option = 0;
            bool order = true;

            while (order)
            {
                Console.Clear();
                FirstLine();
                SpecialRow("Combos");
                SecondLine();
                Row("Items", "Price");
                ThirdLine();
                Row("1. Go Green Combo:", "R90");
                Row("Reggie's Veggie Burger", "");
                Row("One Side", "");
                Row("One Beverage", "");
                ThirdLine();
                Row("2. Double Stack Attack Combo:", "R110");
                Row("Two Double Stacked That's", "");
                Row("That Burgers", "");
                Row("One Side", "");
                ThirdLine();
                Row("3. Friendship Combo:", "R150");
                Row("Two Double Cheese Lockdown Burgers", "");
                Row("Two Sides", "");
                Row("Two Beverages", "");
                ThirdLine();
                Row("4. Family Feast Combo:", "R200");
                Row("Four Sam's Hometown Beef Burgers", "");
                Row("Three Sides", "");
                Row("Four Beverages", "");
                ForthLine();
                SpecialRow("5. Back");
                LastLine();

                Console.WriteLine(Environment.NewLine + "Please choose an option");
                option = int.Parse(Console.ReadLine());

                switch ((Combos)option)
                {
                    case Combos.Green:
                        Items.Add("Go Green Combo");
                        prices.Add(90);
                        break;
                    case Combos.Double:
                        Items.Add("Double Stack Attack Combo");
                        prices.Add(110);
                        break;
                    case Combos.Friends:
                        Items.Add("Friendship Combo");
                        prices.Add(150);
                        break;
                    case Combos.Family:
                        Items.Add("Family Feast Combo");
                        prices.Add(200);
                        break;
                    case Combos.Back:
                        return;
                        break;
                    default:
                        Console.WriteLine("Enter a correct option");
                        break;
                }
            }
            Console.ReadLine();
        }

        // Hamburgers Scope for displaying and purchasing Harmburgers items and adds them to lists for prices and items
        static void Hamburgers(List<String>Items, List<double> prices)
        {
            int option = 0;
            bool order = true;

            while (order)
            {
                Console.Clear();
                FirstLine();
                SpecialRow("Hamburgers");
                SecondLine();
                Row("Items","Price");
                ThirdLine();
                Row("1. Double Cheese Lockdown Burger","R65");
                Row("2. Sam's Hometown Beef Burger","R50");
                Row("3. Thick and Stick Rib Burger" ,"R70");
                Row("4. Reggie's Veggie Burger","R62");
                Row("5. Double Stacked That's That Burger","R75");
                ForthLine();
                SpecialRow("6. Back");
                LastLine();

                Console.WriteLine(Environment.NewLine+"Please choose an option");
                option = int.Parse(Console.ReadLine());

                switch ((Hamburger)option)
                {
                    case Hamburger.Cheese:
                        Items.Add("Double Cheese Lockdown Burger");
                        prices.Add(65);
                        break;
                    case Hamburger.Beef:
                        Items.Add("Sam's Hometown Beef Burger");
                        prices.Add(50);
                        break;
                    case Hamburger.Rib:
                        Items.Add("Thick and Stick Rib Burger");
                        prices.Add(70);
                        break;
                    case Hamburger.Vegie:
                        Items.Add("Reggie's Veggie Burger");
                        prices.Add(62);
                        break;
                    case Hamburger.Stack:
                        Items.Add("Double Stacked That's That Burger");
                        prices.Add(75);
                        break;
                    case Hamburger.Back:
                        order = false;
                        return;
                        break;
                    default:
                        Console.WriteLine("Enter a correct option");
                        break;
                }
            }
            Console.ReadLine();
        }

        // Side Scope for displaying and purchasing Side items and adds them to lists for prices and items
        static void Side(List<String> Items, List<double> Prices)
        {
            int option = 0;
            bool order = true;
            while (order)
            {
                Console.Clear();
                FirstLine();
                SpecialRow("Sides");
                SecondLine();
                Row("Items", "Price");
                ThirdLine();
                Row("1. Fries", "R10");
                Row("2. Onion Rings", "R15");
                Row("3. Green Salad", "R10");
                Row("4. Potato Wedges", "R15");
                ForthLine();
                SpecialRow("5. Back");
                LastLine();


                Console.WriteLine(Environment.NewLine + "Please choose an option");
                option = int.Parse(Console.ReadLine());

                switch ((Sides)option)
                {
                    case Sides.Chips:
                        Items.Add("Fries");
                        Prices.Add(10);
                        break;
                    case Sides.Onion:
                        Items.Add("Onion Rings");
                        Prices.Add(15);
                        break;
                    case Sides.Salad:
                        Items.Add("Green Salad");
                        Prices.Add(10);
                        break;
                    case Sides.Potato:
                        Items.Add("Potato Wedges");
                        Prices.Add(15);
                        break;
                    case Sides.Back:
                        order = false;
                        return;
                        break;
                    default:
                        Console.WriteLine("Please choose a correct option");
                        break;
                }
            }
            Console.ReadLine();
        }

        // Drinks Scope for displaying and purchasing Drinks items and adds them to lists for prices and items
        static void Drinks(List<String> Items, List<double> prices)
        {
            int option = 0;
            bool order = true;

            while (order)
            {
                Console.Clear();
                FirstLine();
                SpecialRow("Beverages");
                SecondLine();
                Row("Items", "Price");
                ThirdLine();
                Row("1. Fruit Juice", "R10");
                Row("2. Soda", "R12");
                Row("3. Milkshake", "R12");
                Row("4. Bubble Tea", "R15");
                Row("5. Coffee", "R10");
                Row("6. Hot Chocolate", "R15");
                ForthLine();
                SpecialRow("7. Back");
                LastLine();

                Console.WriteLine(Environment.NewLine + "Please choose an option");
                option = int.Parse(Console.ReadLine());

                switch ((Beverages)option)
                {
                    case Program.Beverages.Juice:
                        Items.Add("Fruit Juice");
                        prices.Add(10);
                        break;
                    case Program.Beverages.Soda:
                        Items.Add("Soda");
                        prices.Add(12);
                        break;
                    case Program.Beverages.Milkshakes:
                        Items.Add("Milkshake");
                        prices.Add(12);
                        break;
                    case Program.Beverages.Boba:
                        Items.Add("Bubble Tea");
                        prices.Add(15);
                        break;
                    case Program.Beverages.Coffee:
                        Items.Add("Coffee");
                        prices.Add(10);
                        break;
                    case Program.Beverages.Choclate:
                        Items.Add("Hot Chocolate");
                        prices.Add(15);
                        break;
                    case Program.Beverages.Back:
                        order = false;
                        return;
                        break;
                    default:
                        Console.WriteLine("Please choose a correct option");
                        break;
                }
            }
            Console.ReadLine();
        }

        // SupriseMe Scope for displaying and purchasing SupriseMe items and adds them to lists for prices and items
        static void SupriseMe(List<String> Items, List<double> prices)
        {
            int option = 0;
            bool order = true;
            int random = 0;
            
            Random number = new Random();

            random = number.Next(1,3);

            while (order)
            {
                Console.Clear();
                FirstLine();
                SpecialRow("SUPRISE SPECIAL");
                SecondLine();

                if (random==1)
                {
                    Row("Suprise Delux Meal:", "R90");
                    Row("Thick and Stick Rib Burger", "");
                    Row("Two Sides", "");
                }
                if (random==2)
                {
                    Row("Suprise Monster Meal:", "R95");
                    Row("Thick and Stick Rib Burger", "");
                    Row("Double Stacked That's That Burger", "");
                    Row("One Side", "");
                }
                if (random==3)
                {
                    Row("Suprise Munch Crunch Meal:", "R80");
                    Row("Double Stacked That's That Burger", "");
                    Row("Two Sides", "");
                }
                
                ThirdLine();

                Row("1. Buy","2. Back");
                string line;
                Console.ForegroundColor = ConsoleColor.Red;
                line = "╚" + new string('═', 36) + "╩" + new string('═', 36) + "╝";
                Console.WriteLine(line);
                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine(Environment.NewLine + "Please choose an option");
                option = int.Parse(Console.ReadLine());

                switch ((Suprise)option)
                {
                    case Suprise.Agree:
                        if (random == 1)
                        {
                            Items.Add("Suprise Delux Meal");
                            prices.Add(90);
                        }
                        if (random==2)
                        {
                            Items.Add("Suprise Monster Meal");
                            prices.Add(95);
                        }
                        if (random==3)
                        {
                            Items.Add("Suprise Munch Crunch Meal");
                            prices.Add(80);
                        }
                        break;
                    case Suprise.Back:
                        return;
                        break;
                    default:
                        Console.WriteLine("Please choose a correct option");
                        break;
                }
            }
            Console.ReadLine();
        }

        // Login Scope for login for users to ensure they have access 
        static bool Login() // while
        {
            string[,] Users =
            {
                {"Zander","111"},
                {"Sarah","fghY09@1"},
                {"Jan","efi57{j"},
                {"Francois","%crgDS78l"},
                {"Harry","gyyvK#4hh54"}
            };

            string user;
            string pass;

            bool correct = false;

            while (correct == false)
            {
                int index=0;
                Console.Clear();
                FirstLine();
                SpecialRow("THE BURGER JOINT");
                string line;
                Console.ForegroundColor = ConsoleColor.Red;
                line = "╠" + new string('═', 73) + "╣";
                Console.WriteLine(line);
                Console.ForegroundColor = ConsoleColor.White;
                SpecialRow("Login");
                LastLine();

                Console.WriteLine("Please enter a username");
                user = Console.ReadLine();

                Console.WriteLine("Please enter a password");
                pass = Console.ReadLine();

                for (int r = 0; r < Users.GetLength(0); r++)
                {
                    if (Users[r,0] == user)
                    {
                        index = r;
                        break;
                    }
                }

                if (Users[index, 1]== pass)
                {
                    correct = true;
                }

                else
                {
                    Console.WriteLine("Please enter correct username and password");
                    correct = false;
                    Console.ReadLine();
                }
            }

            return correct;
        }
    }
}
