using BowlingBall.Interfaces;
using BowlingBall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Implementations
{
    public class FrameGeneratorService : IFrameGenerator
    {
        public List<Frame> _framesList { get; set; }
        public int _maxFrames { get; set; }
        public int _maxPins { get; set; }


        public FrameGeneratorService(int maxFrames, int maxPins)
        {
            _framesList = new List<Frame>();
            _maxFrames = maxFrames;
            _maxPins = maxPins;
        }

        public List<Frame> GetFrames()
        {
            return _framesList;
        }

        public void GenerateFrame(int pins)
        {
            var currentFrame = _framesList.LastOrDefault();

            //initialise first frame
            if (currentFrame == null)
            {
                var frame = new Frame()
                {
                    FrameID = 1,
                    Rolls = new List<int>() { pins }
                };
                _framesList.Add(frame);
                return;
            }

            var isStrikeAchieved = (currentFrame.Rolls.Count == 1 && currentFrame.Rolls[0] == _maxPins);
            var isSpareAchieved = (currentFrame.Rolls.Count == 2 && currentFrame.Rolls.Sum(x => x) == _maxPins);
            var isLastFrame = currentFrame.FrameID == _maxFrames;

            //generate strike frame
            if (isStrikeAchieved && !isLastFrame)
            {
                var strikeFrame = new StrikeFrame()
                {
                    FrameID = currentFrame.FrameID,
                    Rolls = new List<int>() { currentFrame.Rolls[0] }
                };
                _framesList[currentFrame.FrameID - 1] = strikeFrame;
            }
            //generate spare frame
            else if (isSpareAchieved && !isLastFrame)
            {
                var spareFrame = new SpareFrame()
                {
                    FrameID = currentFrame.FrameID,
                    Rolls = new List<int>() { currentFrame.Rolls[0], currentFrame.Rolls[1] }
                };
                _framesList[currentFrame.FrameID - 1] = spareFrame;
            }
            //generate default frame
            else if (isLastFrame || currentFrame.Rolls.Count < 2)
            {
                if (currentFrame.Rolls.Count != 3)
                    currentFrame.Rolls.Add(pins);
                return;
            }

            //if nothing above matches, then for current roll make another frame
            var newFrame = new Frame()
            {
                FrameID = currentFrame.FrameID + 1,
                Rolls = new List<int>() { pins }
            };
            _framesList.Add(newFrame);

            return;
        }
    }
}
