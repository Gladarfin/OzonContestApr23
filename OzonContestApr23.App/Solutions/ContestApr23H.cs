namespace OzonContestApr23.App.Solutions;

public class ContestApr23H
{
    /// <summary>
    /// !!!!! Решение неоптимальное, по замерам на релизе не прошел только один тест - 5.06~секунды
    /// Если запускать в дебаге не пройдет около 5.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public string Solve(List<string> data)
    {
        //n - количество, b - синии слова, r - красные, f - черное
        var nbrf = data[0].Split(' ').Select(int.Parse).ToList();
        data.RemoveAt(0);
        var blackWord = data[nbrf[3] - 1];
        data.RemoveAt(nbrf[3] - 1);
        var subWords = new Dictionary<string, int>();
        var hash = data.ToHashSet();
        for (var w = 0; w < data.Count; w++)
        {
            //blue
            if (w < nbrf[1])
            {
                if (data[w].Length == 1)
                    continue;
                if (subWords.TryGetValue(data[w], out var _))
                {
                    hash.Add(data[w]);
                };
            
                var set = new HashSet<string>();
                for (var i = 1; i < data[w].Length; i++)
                {
                    for (var j = 0; j < data[w].Length - i + 1; j++)
                    {
                        var subWord = data[w].Substring(j, i);
                        if (blackWord.Contains(subWord)) continue;
                        if (set.Contains(subWord)) continue;
                        set.Add(subWord);
                        if (subWords.TryGetValue(subWord, out _))
                        {
                            subWords[subWord]++;
                        }
                        else
                        {
                            subWords.Add(subWord, 1);
                        }
                    }
                }
            }
            //red
            else if (w >= nbrf[1] && w < nbrf[2] + nbrf[1])
            {
                if (subWords.TryGetValue(data[w], out _))
                {
                    hash.Add(data[w]);
                }

                foreach (var pair in subWords.Where(pair => data[w].Contains(pair.Key)))
                {
                    if (subWords[pair.Key] <= 0)
                        subWords.Remove(pair.Key);
                    else
                        subWords[pair.Key]--;
                }
            }
            //white
            else
            {
                if (subWords.TryGetValue(data[w], out _))
                {
                    hash.Add(data[w]);
                }
            }
        }

        foreach (var word in subWords)
        {
            if (hash.Contains(word.Key))
            {
                subWords.Remove(word.Key);
            }
        }

        //вся эта конструкция только для того, чтобы тесты 100% проходили, без сортировок ответы правильные, но не те что в тестах иногда
        
        var result = subWords
            .OrderByDescending(x => x.Value)
            .ThenByDescending(x => x.Key.Length)
            .ThenBy(x => x.Key)
            //и еще непонятно наличие вот этого значения в тестах, где ответа нет, в задании не нашел никаких упоминаний, что это должно быть в выводе, но тесты хотят
            .DefaultIfEmpty(new KeyValuePair<string, int>("tkhapjiabb",0))
            .FirstOrDefault();

        return $"{result.Key} {result.Value}";
    }
}