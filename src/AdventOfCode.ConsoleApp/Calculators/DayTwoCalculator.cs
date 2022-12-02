using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DayTwoCalculator : AdventOfCodeCalculator
    {
        private const int _loss = 0;
        private const int _draw = 3;
        private const int _win = 6;

        private const string _opponentRock = "A";
        private const string _opponentPaper = "B";
        private const string _opponentScissor = "C";

        private const string _contestantRock = "X";
        private const string _contestantPaper = "Y";
        private const string _contestantScisscor = "Z";

        private const int _rockScore = 1;
        private const int _paperScore = 2;
        private const int _scissorScore = 3;

        public override DayTwoEntity RunCalculation(IEnumerable<AdventOfCodeEntity> dataInput)
        {
            var data = dataInput.Cast<DayTwoEntity>().ToList();

            Dictionary<int, string[]> roundList = new();

            for (int i = 0; i < data.Count; i++)
            {
                roundList.Add(i + 1, data[i].Round.Split(' '));
            }

            int roundLevel = 1;
            int combinedScore = 0;
            foreach (var item in roundList.Values)
            {
                combinedScore += ScoreCalculatorPart2(item[0], item[1], roundLevel);
                roundLevel++;
            }

            Console.WriteLine($"Combined Score in this magical event: {combinedScore}");

            return new DayTwoEntity();
        }

        private static int ScoreCalculatorPart1(string opponentsChoice, string contestantsChoice, int round)
        {
            string oppWeapon = string.Empty;
            string constestantWeapon = string.Empty;
            int roundScore = 0;

            if (opponentsChoice.Equals(_opponentRock))
            {
                oppWeapon = "Rock";
                switch (contestantsChoice)
                {
                    case _contestantRock:
                        roundScore += (_rockScore + _draw);
                        constestantWeapon = "Rock";
                        break;

                    case _contestantPaper:
                        roundScore += (_paperScore + _win);
                        constestantWeapon = "Paper";
                        break;

                    case _contestantScisscor:
                        roundScore += (_scissorScore + _loss);
                        constestantWeapon = "Scissor";
                        break;

                    default:
                        break;
                }
            }

            if (opponentsChoice.Equals(_opponentPaper))
            {
                switch (contestantsChoice)
                {
                    case _contestantRock:
                        roundScore += (_rockScore + _loss);
                        constestantWeapon = "Rock";
                        break;

                    case _contestantPaper:
                        roundScore += (_paperScore + _draw);
                        constestantWeapon = "Paper";
                        break;

                    case _contestantScisscor:
                        roundScore += (_scissorScore + _win);
                        constestantWeapon = "Scissor";
                        break;

                    default:
                        break;
                }
            }

            if (opponentsChoice.Equals(_opponentScissor))
            {
                switch (contestantsChoice)
                {
                    case _contestantRock:
                        roundScore += (_rockScore + _win);
                        constestantWeapon = "Rock";
                        break;

                    case _contestantPaper:
                        roundScore += (_paperScore + _loss);
                        constestantWeapon = "Paper";
                        break;

                    case _contestantScisscor:
                        roundScore += (_scissorScore + _draw);
                        constestantWeapon = "Scissor";
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Round # {round}: Opponent: {opponentsChoice} - {oppWeapon} vs Contestant: {contestantsChoice} - {constestantWeapon}.");
            Console.WriteLine($"Summed Score: {roundScore}");
            Console.WriteLine();
            Console.WriteLine("New round coming up.");

            return roundScore;

        }

        private static int ScoreCalculatorPart2(string opponentsChoice, string roundPrediction, int round)
        {
            int roundScore = 0;

            // Lose
            if (roundPrediction.Equals(_contestantRock))
            {
                switch (opponentsChoice)
                {
                    case _opponentRock:
                        roundScore += (_loss + _scissorScore);
                        break;

                    case _opponentPaper:
                        roundScore += (_loss + _rockScore);
                        break;

                    case _opponentScissor:
                        roundScore += (_loss + _paperScore);
                        break;

                    default:
                        break;
                }
            }

            // Draw
            if (roundPrediction.Equals(_contestantPaper))
            {
                switch (opponentsChoice)
                {
                    case _opponentRock:
                        roundScore += (_draw + _rockScore);
                        break;

                    case _opponentPaper:
                        roundScore += (_draw + _paperScore);
                        break;

                    case _opponentScissor:
                        roundScore += (_draw + _scissorScore);
                        break;

                    default:
                        break;
                }
            }

            // Win
            if (roundPrediction.Equals(_contestantScisscor))
            {
                switch (opponentsChoice)
                {
                    case _opponentRock:
                        roundScore += (_win + _paperScore);
                        break;

                    case _opponentPaper:
                        roundScore += (_win + _scissorScore);
                        break;

                    case _opponentScissor:
                        roundScore += (_win + _rockScore);
                        break;

                    default:
                        break;
                }
            }


            Console.WriteLine($"Round # {round}: Opponent: {opponentsChoice}.");
            Console.WriteLine($"Summed Score: {roundScore}");
            Console.WriteLine();
            Console.WriteLine("New round coming up.");

            return roundScore;
        }
    }
}
