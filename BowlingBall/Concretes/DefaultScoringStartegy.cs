using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingBall.Models;

namespace BowlingBall.Implementations
{
    public class DefaultScoringStartegy : IScoringStartegy
    {
        public int GetScores(int frameId, List<Frame> FramesList, int maxPins)
        {
            var score = FramesList.Single(x => x.FrameID == frameId).Rolls.Sum(x => x);
            return score;
        }
    }
}
