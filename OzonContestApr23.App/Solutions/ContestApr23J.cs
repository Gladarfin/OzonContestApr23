namespace OzonContestApr23.App.Solutions;

public class ContestApr23J
{
    public List<string> Solve(List<string> data)
    {
        var n = int.Parse(data[0].Split(' ')[0]);
        var w = int.Parse(data[0].Split(' ')[1]);
        var k = int.Parse(data[0].Split(' ')[2]);

        if (w > n && k == 1)
        {
            var l = int.Parse(data[1].Split(' ')[0]) - w + 1 < 1 ? 1 : int.Parse(data[1].Split(' ')[0]) - w + 1 ;
            var r = int.Parse(data.Last().Split(' ')[0]) + w - 1;
            return new List<string> { "1", $"{l}-{r}" };
        }

        data.RemoveAt(0);

        var dict = data.Select(x => x.Split(' '))
            .GroupBy(x => new { time = int.Parse(x[0]), ip = x[1] })
            .Select(g => new { time = g.Key.time, 
                ip = g.Key.ip, 
                count = g.Count() })
            .GroupBy(x => x.time)
            .ToDictionary(y => y.Key, 
                y => y.Select(yx => (yx.ip, yx.count)).ToList());
        
        var intervals = new List<int[]>();
        
        for (var i = 1; i <= dict.Last().Key; i++)
        {
            var isAttacked = dict.Where(x => x.Key >= i && x.Key <= i + w - 1)
                .SelectMany(x => x.Value)
                .GroupBy(x => x.ip)
                .Any(g => g.Sum(gx => gx.count) >= k);
        
            if (isAttacked)
            {
                intervals.Add(new []{i, i + w - 1});
            }
        }

        if (intervals.Count == 0)
            return new List<string>{"0"};

        var result = MergeIntervals(intervals);
        result.Insert(0, result.Count.ToString());
        return result;
    }

    private List<string> MergeIntervals(List<int[]> intervals)
    {
        var stack = new Stack<int[]>();

        stack.Push(intervals[0]);

        for (var i = 1; i < intervals.Count; i++)
        {
            if (intervals[i][0] <= stack.Peek()[1] + 1)
            {
                var top = stack.Pop();
                top[1] = Math.Max(top[1], intervals[i][1]);
                stack.Push(top);
                continue;
            }
            stack.Push(intervals[i]);
        }
        return stack.OrderBy(x => x[0])
            .Select(x => $"{x[0]}-{x[1]}").ToList();
    }
}