namespace OzonContestApr23.App.Solutions;

public class ContestApr23G
{
    public List<string> Solve(List<string> data)
    {
        var maxSum = int.Parse(data[1]);
        var goodsWithPrice = data.Skip(2)
            .Select(x => x.Split(' '))
            .Select(a => new { Code = int.Parse(a[0]), Price = int.Parse(a[1]) })
            .GroupBy(x => x.Code)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.Price));
        var result = new List<List<string>>();
        var curSum = 0;
        foreach (var val in goodsWithPrice)
        {
            var code = val.Key;
            var sum = val.Value;
            if (curSum != 0)
            {
                if (sum < curSum)
                {
                    result[^1].Add($"{code} {sum}");
                    curSum -= sum;
                    continue;
                }
                
                result[^1].Add($"{code} {curSum}");
                sum -= curSum;
                curSum = 0;
            }
            
            while (sum >= maxSum)
            {
                result.Add(new List<string> {$"{code} {maxSum}" });
                sum -= maxSum;
            }

            if (sum <= 0) continue;
                
            result.Add(new List<string> {$"{code} {sum}"});
            curSum = maxSum - sum;
        }

        foreach (var list in result)
        {
            list.Insert(0, list.Count.ToString());
        }

        var lst = result.SelectMany(x => x).ToList();
        lst.Insert(0, result.Count.ToString());
        
        return lst;
    }
}