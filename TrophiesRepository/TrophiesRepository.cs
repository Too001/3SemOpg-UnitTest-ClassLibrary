using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3SemObligatoriskOpgave_1_og_2.TrophyRepository
{
    public interface TrophiesRepository
    {
        IEnumerable<Trophy> Get(int? yearAfter = null, string? competitionIncludes = null, string? sortBy = null);
        Trophy? GetById(int id);
        Trophy Add(Trophy trophy);
        Trophy? Remove(int id);
        Trophy? Update(int id, Trophy trophy);

    }
}
