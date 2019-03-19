using BowlingBall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Implementations
{
    public interface IScoringStartegy
    {
        int GetScores(int frameId, List<Frame> FramesList, int maxPins);
    }
}
