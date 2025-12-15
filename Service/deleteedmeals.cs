using FitnessTrackerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackerApp.Service
{
    internal class deleteedmeals
    {
        public CheatMealEntry Meal { get; set; }
        public WeightEntry Weight { get; set; }

        public deleteedmeals(CheatMealEntry meal, WeightEntry weight)
        {
            Meal = meal;
            Weight = weight;
        }
    }
}
