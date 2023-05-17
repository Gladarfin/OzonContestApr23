namespace OzonContestApr23.App.Solutions;
public class ContestApr23I
{
    public List<string> Solve(List<string> data)
    {
        var listOfArrays = data.Skip(1)
            .Select(x => x.Split(' ')
                .Select(int.Parse)
                .ToArray())
            .OrderBy(x => x.Length)
            .ThenBy(x => x[0])
            .ToList();

        if (listOfArrays[0].Length > 1)
            return new List<string> { "NO" };

        var pairsCount = int.Parse(data[0]) - 1;
        var dict = new Dictionary<int, int>();
        var leaves = new List<int>();

        foreach (var value in listOfArrays)
        {
            if (value.Length == 1)
            {
                if (dict.ContainsKey(value[0]))
                    return new List<string> { "NO" };
                dict.Add(value[0], -1);
                leaves.Add(value[0]);
                continue;
            }

            var curParent = -100;

            foreach (var val in value)
            {
                if (dict.ContainsKey(val))
                {
                    if (dict[val] != -1)
                    {
                        if (!value.Contains(dict[val]))
                            return new List<string> { "NO" };
                    }
                    continue;
                }

                dict.Add(val, -1);
                curParent = val;
                foreach (var curValue in value)
                {
                    if (val == curValue)
                        continue;
                    dict.TryGetValue(curValue, out var curVal);
                    if (curVal == -1)
                    {
                        dict[curValue] = val;
                    }
                    else
                    {
                        if (!value.Contains(curVal))
                            return new List<string> { "NO" };
                    }
                }

                break;
            }

            foreach (var parent in value)
            {
                if (parent == curParent || leaves.Contains(parent))
                    continue;
                var children = dict.Where(x => x.Value == parent).Select(x => x.Key).ToList();
                if (children.Any(key => !value.Contains(key)))
                {
                    return new List<string> { "NO" };
                }
            }
        }

        if (dict.Count - 1 != pairsCount)
            return new List<string> { "NO" };

        if (dict.Count(x => x.Value == -1) > 1)
            return new List<string> { "NO" };

        var result = dict.Where(x => x.Value != -1)
            .OrderBy(x => x.Value)
            .ThenBy(y => y.Key)
            .Select(x => $"{x.Value} {x.Key}")
            .ToList();
        result.Insert(0, "YES");
        return result;
    }
}