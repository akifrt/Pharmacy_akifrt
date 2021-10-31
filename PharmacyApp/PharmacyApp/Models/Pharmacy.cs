using PharmacyApp.Helper;
using System;
using System.Collections.Generic;

namespace PharmacyApp.Models
{
    class Pharmacy
    {
        public string Name { get; }
        public int Id { get; }

        public List<Drug> Drugs = new List<Drug>();

        public Pharmacy(string name)
        {
            Name = name;
        }
        public bool AddtoPharmacy(Drug drug)
        {
            Drug newDrug = Drugs.Find(x => x.Name.ToLower().Contains(drug.Name.ToLower().Trim()));

            if(newDrug != null)
            {
                newDrug.Count += drug.Count;
                return false;
            }
            Drugs.Add(drug);
            return true;
        }

        public void ShowAllDrugs()
        {
            foreach(Drug drug in Drugs)
            {
                Extensions.Print($"{drug}", ConsoleColor.Green);
            }
        }

        public bool InfoDrug(string name)
        {
            var newDrug = Drugs.FindAll(x => x.Name.ToLower().Contains(name.ToLower().Trim()));

            foreach(var drug in newDrug)
            {
                Extensions.Print($"{drug}", ConsoleColor.Green);
            }

            return false;
        }

        public bool SaleDrug(string drugName, double payed, int countOfDrugs)
        {
            Drug drugs = Drugs.Find(x => x.Name.ToLower().Contains(drugName.Trim().ToLower()));
            if (drugs != null)
            {
                if (drugs.Count >= countOfDrugs)
                {
                    if (drugs.Price * countOfDrugs <= payed)
                    {
                        drugs.Count -= countOfDrugs;
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
