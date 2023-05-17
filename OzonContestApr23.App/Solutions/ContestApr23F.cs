using System.Text;

namespace OzonContestApr23.App.Solutions;

public class ContestApr23F
{
    public string Solve(string data)
    {
        var dataArray = data.Split(' ').Select(int.Parse).ToArray();
        var result = new List<int>();
        var answer = new StringBuilder();

        while (dataArray.Length > 0)
        {
            //nextElement == toLeftCount
            var nextElement = Array.IndexOf(dataArray, dataArray.Min());
            var toRightCount = dataArray.Length - nextElement;

            if (nextElement <= toRightCount)
            {
                for (var i = 0; i < nextElement; i++)
                {
                    ShiftToLeft(dataArray);
                    answer.Append('L');
                }
            }
            else
            {
                for (var i = 0; i < toRightCount; i++)
                {
                    ShiftToRight(dataArray);
                    answer.Append('R');
                }
            }
            result.Add(dataArray[0]);
            answer.Append('!');
            dataArray = dataArray.Skip(1).ToArray();
        }
        
        return answer.ToString();
    }

    private void ShiftToRight(int[] array)
    {
        var last = array[^1];
        Buffer.BlockCopy(array, 0, array, 4, (array.Length - 1) * 4);
        array[0] = last;
    }

    private void ShiftToLeft(int[] array)
    {
        var first = array[0];
        Buffer.BlockCopy(array, 4, array, 0, (array.Length - 1) * 4);
        array[^1] = first;
    }
}