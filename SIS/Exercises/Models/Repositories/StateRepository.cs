using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercises.Models.Repositories
{
    public class StateRepository
    {
        private static List<State> _courses;

        static StateRepository()
        {
            // sample data
            _courses = new List<State>
            {
                new State { StateAbbreviation="KY", StateName="Kentucky" },
                new State { StateAbbreviation="MN", StateName="Minnesota" },
                new State { StateAbbreviation="OH", StateName="Ohio" },
            };
        }

        public static IEnumerable<State> GetAll()
        {
            return _courses;
        }

        public static State Get(string stateAbbreviation)
        {
            return _courses.FirstOrDefault(c => c.StateAbbreviation == stateAbbreviation);
        }

        public static void Add(State state)
        {
            _courses.Add(state);
        }

        public static void Edit(State state)
        {
            var selectedState = _courses.FirstOrDefault(c => c.StateAbbreviation == state.StateAbbreviation);

            selectedState.StateName = state.StateName;
        }

        public static void Delete(string stateAbbreviation)
        {
            _courses.RemoveAll(c => c.StateAbbreviation == stateAbbreviation);
        }
    }
}