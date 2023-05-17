namespace OzonContestApr23.App.Solutions;

public class ContestApr23C
{
    public string Solve(string data)
    {
        var dataArray = data.Split(' ').Select(int.Parse).ToList();
        var dict = new Dictionary<int, bool>();
        var i = 0;
        while (i < dataArray.Count)
        {
            var curVertex = dataArray[i];
            if (!dict.ContainsKey(curVertex))
                dict[curVertex] = false;
            var children = dataArray[i + 1];
            i += 2;

            for (var j = 0; j < children; j++)
            {
                dict[dataArray[i]] = true;
                i++;
            }
        }

        var root = dict.Single(x => !x.Value).Key.ToString();
        return root;
    }
}