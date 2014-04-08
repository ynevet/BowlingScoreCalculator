using System;

namespace BowlingScore.Models
{
    public class BowlingGame
    {
        private int[] _rolls = new int[21];
        private int _currentRollIndex = 0;

        public void Roll(int numPins)
        {
            if (_currentRollIndex > 20)
                throw new InvalidOperationException("Game is already over!");

            _rolls[_currentRollIndex] = numPins;
            _currentRollIndex++;
        }

        public int CalculateScore()
        {
            int score = 0;
            int frameIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                int frameScore;
                if (IsStrikeFrame(frameIndex))
                {
                    frameScore = 10 + GrantStrikeBonus(frameIndex);
                    frameIndex++;
                }
                else
                {
                    frameScore = SumOfFrame(frameIndex);
                    if (IsSpareFrame(frame))
                    {
                        frameScore += GrantSpareBonus(frameIndex);
                    }

                    frameIndex += 2;
                }

                score += frameScore;
            }

            return score;
        }

        private int SumOfFrame(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        private int GrantSpareBonus(int frameIndex)
        {
            int spareBonus = _rolls[frameIndex + 2];
            return spareBonus;
        }

        private int GrantStrikeBonus(int frameIndex)
        {
            var strikeBonus = _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
            return strikeBonus;
        }

        private bool IsStrikeFrame(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }

        private bool IsSpareFrame(int frame)
        {
            return _rolls[frame] + _rolls[frame + 1] == 10;
        }
    }
}