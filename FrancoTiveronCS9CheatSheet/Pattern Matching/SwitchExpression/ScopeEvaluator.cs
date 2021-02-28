namespace FrancoTiveronCS9CheatSheet.Pattern_Matching.SwitchExpression
{
    public static class ScopeEvaluator
    {
        public static string SwitchStatement(int score)
        {
            string resultDescription = string.Empty;

            switch (score)
            {
                case 0:
                    resultDescription = "Unclassified";
                    break;
                case 1:
                case 2:
                case 3:
                    resultDescription = "Bad";
                    break;
                case 4:
                case 5:
                    resultDescription = "Ordinary";
                    break;
                case 6:
                case 7:
                    resultDescription = "Good";
                    break;
                case 8:
                case 9:
                    resultDescription = "Excellent";
                    break;
                case 10:
                    resultDescription = "Outstanding";
                    break;
                default:
                    resultDescription = "Invalid Score";
                    break;
            }

            return resultDescription;
        }

        public static string SwitchExpression(int score) => score switch
        {
            0 => "Unclassified",
            >0 and <= 3 => "Bad",
            4 or 5 => "Ordinary",
            6 or 7 => "Good",
            8 or 9 => "Excellent",
            10 => "Outstanding",
            _ => "Invalid Score"
        };
    }
}
