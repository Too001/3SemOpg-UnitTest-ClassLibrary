using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3SemObligatoriskOpgave_1_og_2.TrophiesRepository
{
    public class TrophiesRepositoryList
    {
        private int _nextId = 1;
        private readonly List<Trophy> _trophies = new();

        public TrophiesRepositoryList()
        { // create 5 trophies.
            _trophies.Add(new Trophy() { Id = _nextId++, Competetion = "Archer", Year = 2010 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competetion = "Shooting", Year = 2000 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competetion = "CubeSolve", Year = 1999 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competetion = "Puzzle", Year = 2015 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competetion = "UEFA Football", Year = 2020 });
        }

        // add a trophy
        public Trophy Add(Trophy trophy)
        {
            trophy.Validate();
            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }

        // Get all list of trophies
        public List<Trophy> GetAll()
        {
            return new List<Trophy>(_trophies);
        }

        // Get trophy by id
        public Trophy? GetById(int id)
        {
            return _trophies.Find(trophy => trophy.Id == id);
        }

        // Remove
        public Trophy? Remove(int id)
        {
            Trophy? trophy = GetById(id);
            if (trophy == null)
            {
                return null;
            }
            _trophies.Remove(trophy);
            return trophy;
        }

        // update trophy by id
        public Trophy? Update(int id, Trophy trophy)
        {
            trophy.Validate();
            Trophy? existingTrophy = GetById(id);
            if (existingTrophy == null)
            {
                return null;
            }
            existingTrophy.Competetion = trophy.Competetion;
            existingTrophy.Year = trophy.Year;
            return existingTrophy;
        }

        // Trophy Get by competition or year.
        public IEnumerable<Trophy> Get(int? yearAfter = null, string? competitionIncludes = null, string? sortBy = null)
        {
            IEnumerable<Trophy> result = new List<Trophy>(_trophies);
            if (yearAfter != null)
            {
                result = result.Where(m => m.Year > yearAfter);
            }
            if (competitionIncludes != null)
            {
                result = result.Where(m => m.Competetion.Contains(competitionIncludes));
            }

            if (sortBy != null)
            {
                sortBy = sortBy.ToLower();
                switch (sortBy)
                {
                    case "competition":
                    case "competition_asc": // ascending - op af
                        result = result.OrderBy(m => m.Competetion);
                        break;
                    case "competition_desc": // Descending - ned af
                        result = result.OrderByDescending(m => m.Competetion);
                        break;
                    case "year":
                    case "year_asc":
                        result = result.OrderBy(m => m.Year);
                        break;
                    case "year_desc":
                        result = result.OrderByDescending(m => m.Year);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
