using System.Text;

namespace OzonContestApr23.App.Solutions;

public class ContestApr23D
{
    private List<int> Sequence { get; set; }
    public string Solve(string data)
    {
       Sequence  = data.Split(' ').Select(int.Parse).ToList();
       var result = new List<int>();
       for (var i = 0; i < Sequence.Count; i++)
       {
           result.Add(Sequence[i]);
           
           if (i + 1 == Sequence.Count)
           {
               result.Add(0);
               break;
           }
           var subSequenceLength = GetSubSequenceLength(i, 1);
           var k = -1;
           if (subSequenceLength == 0)
           {
               k = 1;
               subSequenceLength = GetSubSequenceLength(i, -1);
           }
           result.Add(k * subSequenceLength);
           i += subSequenceLength;
       }
        
       return string.Join(' ', result);
    }

    private int GetSubSequenceLength(int index, int diffValue)
    {
        var cur = Sequence[index] - Sequence[index + 1];
        var count = 0;
        while (cur == diffValue)
        {
            count++;
            index++;
            if (index + 1 == Sequence.Count)
                break;
            cur = Sequence[index] - Sequence[index + 1];
        }
        return count;
    }
}