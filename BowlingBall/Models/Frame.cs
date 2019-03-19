using BowlingBall.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Models
{
    public class Frame
    {
        protected IScoringStartegy _strategy;

        public Frame()
        {
            _strategy = new DefaultScoringStartegy();
        }

        public int FrameID { get; set; }
        public List<int> Rolls { get; set; }
        public int Score { get; set; }
        public virtual int CalculateScore(List<Frame> _frames, int maxPins)
        {
           return _strategy.GetScores(FrameID, _frames, maxPins);
        }
    }
}
