using System;
using System.Collections.Generic;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name,int neededRenovators,string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
            Count = 0;
        }

        public List<Renovator> Renovators { get; set; }

        public string Name { get; set; }

        public int NeededRenovators { get; set; }

        public string Project { get; set; }

        public int Count { get; set; }

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null || renovator.Name == string.Empty || renovator.Type == null || renovator.Type == string.Empty)
            {
                return "Invalid renovator's information.";
            }

            if (!(Renovators.Count<NeededRenovators))
            {
                return "Renovators are no more needed.";

            }

            if (renovator.Rate>350)
            {
                return "Invalid renovator's rate.";
            }

            else
            {
                Renovators.Add(renovator);
                Count++;
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            for (int i = 0; i < Renovators.Count; i++)
            {
                if (Renovators[i].Name == name)
                {
                    Renovators.RemoveAt(i);
                    Count--;
                    return true;
                }        
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int removed = 0;

            for (int i = 0; i < Renovators.Count; i++)
            {
                if (Renovators[i].Type == type)
                {
                    Renovators.RemoveAt(i);
                    Count--;
                    i--;
                    removed++;
                }
            }

            return removed;
        }

        public Renovator HireRenovator(string name)
        {
            for (int i = 0; i < Renovators.Count; i++)
            {
                if (Renovators[i].Name == name)
                {
                    Renovators[i].Hired = true;
                    return Renovators[i];
                    
                    
                }
            }

            return null;
        }

       public List<Renovator> PayRenovators(int days)
        { 
            List<Renovator> worked = new List<Renovator>();

            foreach (var ren in Renovators)
            {
                if (ren.Days>=days)
                {
                    worked.Add(ren);
                }
            }

            return worked;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var reno in Renovators)
            {
               /* -Renovator: Pesho
           --Specialty: Tiles
           --Rate per day: 200 BGN*/

                if (!reno.Hired)
                {
                    sb.AppendLine($"-Renovator: {reno.Name}");
                    sb.AppendLine($"--Specialty: {reno.Type}");
                    sb.AppendLine($"--Rate per day: {reno.Rate} BGN");
                }
            }

            return sb.ToString().TrimEnd();
        }

    }
}
