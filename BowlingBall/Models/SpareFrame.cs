using BowlingBall.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Models
{
    public class SpareFrame : Frame
    {
        public SpareFrame()
        {
            _strategy = new SpareScoringStartegy();
        }
        public override int CalculateScore(List<Frame> _frames, int maxPins)
        {
            return _strategy.GetScores(FrameID, _frames, maxPins);
        }
    }
}
