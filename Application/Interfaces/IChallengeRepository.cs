using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IChallengeRepository
    {
        IReadOnlyList<Challenge> GetAllChallenges();
        Challenge GetChallenge(int id);
        Challenge CreateChallenge(Challenge challenge);
        bool ChallengeExist(int id);
    }
}
