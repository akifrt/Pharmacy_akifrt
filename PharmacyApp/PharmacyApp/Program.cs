using PharmacyApp.Helper;
using PharmacyApp.Models;
using System;

namespace PharmacyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pharmacy Application in C#\r");
            Console.WriteLine("--------------------------\n");

            int drugCount, drugPrice, drugID, drugCost;

            Pharmacy pharmacy = new Pharmacy("Europe pharmacy");

            while (true)
            {
                Extensions.Print("Choose one", ConsoleColor.Cyan);
                Extensions.Print(" 1 - AddDrug\n " +
                "2 - InfoDrug\n " +
                "3 - ShowAllDrugs\n " +
                "4 - SaleDrug\n " +
                "5 - Exit", ConsoleColor.Cyan);
                bool checkAnswer = int.TryParse(Console.ReadLine(), out int result);
                if (checkAnswer && (result >= 1 && result <= 5))
                {
                    if(result == 5)
                    {
                        Extensions.Print("Bye", ConsoleColor.Red);
                        break;
                    }
                    switch (result)
                    {
                        case 1:
                            Extensions.Print("input Drug Name", ConsoleColor.Yellow);
                            string drugName = Console.ReadLine();
                            if (drugName.Length == 0)
                            {
                                Extensions.Print("drug name can't be an empty string", ConsoleColor.Red);
                                goto case 1;
                            }
                            checkAnswer = int.TryParse(drugName, out int tempName);
                            if (checkAnswer)
                            {
                                Extensions.Print("drug Name can't be a number", ConsoleColor.Red);
                                goto case 1;
                            }
                            Extensions.Print("input Drug Type", ConsoleColor.Yellow);
                            string drugType = Console.ReadLine();
                            if (drugType.Length == 0)
                            {
                                Extensions.Print("drug type can't be an empty string", ConsoleColor.Red);
                                goto case 1;
                            }
                            checkAnswer = int.TryParse(drugType, out int tempType);
                            if (checkAnswer)
                            {
                                Extensions.Print("drug Type can't be a number", ConsoleColor.Red);
                                goto case 1;
                            }
                            Extensions.Print("input Drug Count", ConsoleColor.Yellow);
                            while (!int.TryParse(Console.ReadLine(), out drugCount))
                            {
                                Extensions.Print("This is not a number!", ConsoleColor.Red);
                            }
                            Extensions.Print("input Drug Price", ConsoleColor.Yellow);
                            while (!int.TryParse(Console.ReadLine(), out drugPrice))
                            {
                                Extensions.Print("This is not a number!", ConsoleColor.Red);
                            }
                            if (pharmacy.AddtoPharmacy(new Drug(drugName, new DrugType(drugType), drugCount, drugPrice)))
                            {
                                Extensions.Print("New drug added", ConsoleColor.Green);
                                pharmacy.ShowAllDrugs();
                            }
                            else
                            {
                                Extensions.Print("Old drug change count", ConsoleColor.Blue);
                                pharmacy.ShowAllDrugs();
                            }
                            break;
                        case 2:
                            if(pharmacy.Drugs.Count == 0)
                            {
                                Extensions.Print("First add drugs", ConsoleColor.Yellow);
                                goto case 1;
                            }
                            Extensions.Print("Input the drug name to check in pharmacy", ConsoleColor.Yellow);
                            drugName = Console.ReadLine();
                            pharmacy.InfoDrug(drugName);
                            break;
                        case 3:
                            if (pharmacy.Drugs.Count == 0)
                            {
                                Extensions.Print("There is no drugs in pharmacy", ConsoleColor.Yellow);
                            }
                            pharmacy.ShowAllDrugs();
                            break;
                        case 4:
                            if(pharmacy.Drugs.Count == 0)
                            {
                                Extensions.Print("First add drugs", ConsoleColor.Red);
                                goto case 1;
                            }
                            pharmacy.ShowAllDrugs();
                            Extensions.Print("input Drug Name", ConsoleColor.Yellow);
                            drugName = Console.ReadLine();
                            if (drugName.Length == 0)
                            {
                                Extensions.Print("drug name can't be an empty string", ConsoleColor.Red);
                                goto case 1;
                            }
                            checkAnswer = int.TryParse(drugName, out tempName);
                            if (checkAnswer)
                            {
                                Extensions.Print("drug Name can't be a number", ConsoleColor.Red);
                                goto case 1;
                            }
                            Extensions.Print("input Drug Count", ConsoleColor.Yellow);
                            while (!int.TryParse(Console.ReadLine(), out drugCount))
                            {
                                Extensions.Print("This is not a number!", ConsoleColor.Red);
                            }
                            Extensions.Print("Make the purchase", ConsoleColor.Yellow);
                            while (!int.TryParse(Console.ReadLine(), out drugCost))
                            {
                                Extensions.Print("This is not a number!", ConsoleColor.Red);
                            }
                            if (!pharmacy.SaleDrug(drugName, drugCost, drugCount))
                            {
                                Extensions.Print(string.Format("Something went wrong", drugName), ConsoleColor.Red);
                            }
                            else
                            {
                                Extensions.Print("Purchase was successful", ConsoleColor.Red);
                            }
                            break;
                    }
                }
                else
                {
                    Extensions.Print("Input must be a number", ConsoleColor.Red);
                }
            }
        }
    }
}
