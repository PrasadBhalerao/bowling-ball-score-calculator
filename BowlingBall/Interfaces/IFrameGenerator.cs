using BowlingBall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Interfaces
{
    public interface IFrameGenerator
    {
        List<Frame> GetFrames();
        void GenerateFrame(int pins);
    }
}
