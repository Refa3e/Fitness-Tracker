using FitnessTrackerApp.Exceptions;
using FitnessTrackerApp.Model;
using System;
using System.Collections.Generic;

namespace FitnessTrackerApp.Service
{
    public class WorkoutService
    {
        private readonly WeightEntryService weightService = new WeightEntryService();

        private List<WorkoutEntry> GetAllWorkouts()
        {
            return DataStorage.LoadData<WorkoutEntry>();
        }

        public List<WorkoutEntry> GetWorkoutsAscending(string username)
        {
            List<WorkoutEntry> allWorkouts = GetAllWorkouts();
            List<WorkoutEntry> workouts = new List<WorkoutEntry>();

            foreach (WorkoutEntry workout in allWorkouts)
            {
                if (string.Equals(workout.UserName, username, System.StringComparison.OrdinalIgnoreCase))
                {
                    workouts.Add(workout);
                }
            }

            workouts.Sort((a, b) => a.Date.CompareTo(b.Date));
            return workouts;
        }

        public List<WorkoutEntry> GetWorkoutsDescending(string username)
        {
            List<WorkoutEntry> ascending = GetWorkoutsAscending(username);
            ascending.Reverse();
            return ascending;
        }

        public WorkoutEntry GetLatestWorkout(string username)
        {
            List<WorkoutEntry> workouts = GetWorkoutsDescending(username);

            if (workouts.Count == 0)
            {
                return new WorkoutEntry();
            }

            return workouts[0];
        }

        public WorkoutEntry GetWorkoutByGuid(string guid)
        {
            List<WorkoutEntry> allWorkouts = GetAllWorkouts();

            foreach (WorkoutEntry workout in allWorkouts)
            {
                if (workout.GUID == guid)
                {
                    return workout;
                }
            }

            return null;
        }

        public void AddNewWorkout(WorkoutEntry newWorkout, WeightEntry newWeight)
        {
            WeightEntry savedWeight = weightService.AddNewEntry(newWeight);

            newWorkout.WeightEntryGUID = savedWeight.GUID;
            newWorkout.GUID = Guid.NewGuid().ToString();

            List<WorkoutEntry> allWorkouts = GetAllWorkouts();
            allWorkouts.Add(newWorkout);
            DataStorage.SaveData(allWorkouts);
        }

        public void UpdateWorkout(WorkoutEntry updatedWorkout, WeightEntry updatedWeight)
        {
            List<WorkoutEntry> allWorkouts = GetAllWorkouts();
            WorkoutEntry workout = GetWorkoutByGuid(updatedWorkout.GUID);

            if (workout == null)
            {
                throw new RecordNotFoundExeption(updatedWorkout.GUID);
            }

            workout.WorkoutName = updatedWorkout.WorkoutName;
            workout.Intensity = updatedWorkout.Intensity;
            workout.CaloriesBurned = updatedWorkout.CaloriesBurned;
            workout.Date = updatedWorkout.Date;

            weightService.UpdateEntry(updatedWeight, workout.WeightEntryGUID);

            DataStorage.SaveData(allWorkouts);
        }

        public void DeleteWorkout(string guid)
        {
            List<WorkoutEntry> allWorkouts = GetAllWorkouts();
            WorkoutEntry workout = GetWorkoutByGuid(guid);

            if (workout == null)
            {
                throw new RecordNotFoundExeption(guid);
            }

            weightService.DeleteEntry(workout.WeightEntryGUID);

            allWorkouts.Remove(workout);
            DataStorage.SaveData(allWorkouts);
        }

        public bool IsWeightUsedInWorkout(string weightGuid)
        {
            List<WorkoutEntry> allWorkouts = GetAllWorkouts();

            foreach (WorkoutEntry workout in allWorkouts)
            {
                if (workout.WeightEntryGUID == weightGuid)
                {
                    return true;
                }
            }

            return false;
        }
    }
}