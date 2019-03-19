using BowlingBall.Implementations;
using BowlingBall.Interfaces;
using BowlingBall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        private IFrameGenerator _frameGeneratorService;
        private int _maxPins;

        public Game(int maxFrames, int maxPins)
        {
            _frameGeneratorService = new FrameGeneratorService(maxFrames, maxPins);
            _maxPins = maxPins;
        }

        public void Roll(int pins)
        {
            _frameGeneratorService.GenerateFrame(pins);
        }

        public int GetScore()
        {
            int score = 0;

            var frames = _frameGeneratorService.GetFrames();

            foreach (var frame in frames)
            {
                score += frame.CalculateScore(frames, _maxPins);
            }
            return score;
        }
    }
}
