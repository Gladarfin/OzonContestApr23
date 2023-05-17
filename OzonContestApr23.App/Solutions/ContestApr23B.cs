using System.Text;

namespace OzonContestApr23.App.Solutions;

public class ContestApr23B
{
    public List<string> Solve(List<string> data)
    {
        var result = new List<string>();

        var consonants = new HashSet<char>{'b', 'c', 'd','f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
        var consonantsEnding = new HashSet<string> {"s", "sh", "ch", "x", "z"};
        foreach (var word in data)
        {
            var lastChar = word[^1];
            var penChar = word[^2];
            
            if (consonantsEnding.Contains(lastChar.ToString()) || consonantsEnding.Contains($"{penChar}{lastChar}"))
            {
                result.Add(word + "es");
                continue;
            }
            
            if (lastChar == 'y' && consonants.Contains(penChar))
            {
                result.Add(word.Remove(word.Length - 1, 1) + "ies");
                continue;
            }
            
            result.Add(word + "s");
        }
        return result;
    }
}