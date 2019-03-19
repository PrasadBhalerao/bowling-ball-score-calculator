using BowlingBall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Implementations
{
    public class StrikeScoringStartegy : IScoringStartegy
    {
        public int GetScores(int frameId, List<Frame> framesList, int maxPins)
        {
            var score = framesList.Single(x => x.FrameID == frameId).Rolls.Sum(x => x);

            //get next frame score
            var nextFrame = framesList.SingleOrDefault(x => x.FrameID == (frameId + 1));
            if (nextFrame != null)
            {
                //next roll
                var nextFrameRolls = nextFrame.Rolls?.Count;

                if (nextFrameRolls > 0)
                {
                    score += framesList[frameId].Rolls[0];
                }

                //next + 1 roll
                if (nextFrameRolls > 1)
                {
                    score += framesList[frameId].Rolls[1];
                    return score;
                }
            }

            //get next + 1 frame score
            var nextToNextFrame = framesList.SingleOrDefault(x => x.FrameID == (frameId + 2));

            if (nextToNextFrame != null)
            {
                var isRollAvailable = nextToNextFrame.Rolls?.Count > 0;

                if (isRollAvailable)
                {
                    score += nextToNextFrame.Rolls[0];
                }
            }
            return score;
        }
    }
}
