using System.Text;

namespace OzonContestApr23.App.Solutions;

public class ContestApr23E
{
    public List<string> Solve(string data)
    {
        var result = new List<StringBuilder>{new StringBuilder()};
        var cursorPos = 0;
        var currentString = 0;

        foreach (var symbol in data)
        {
            //строчная буква / цифра
            if (IsDigitOrLowerCase(symbol))
            {
                result[currentString].Insert(cursorPos, symbol);
                cursorPos++;
                continue;
            }
            //L двигаем курсор влево.
            if (symbol == 76)
            {
                cursorPos = cursorPos > 0 ? cursorPos - 1 : 0;
                continue;
            }
            //R двигаем курсор вправо
            if (symbol == 82)
            {
                cursorPos = cursorPos == result[currentString].Length ? cursorPos : cursorPos + 1;
                continue;
            }
            //U нажатие стрелки вверх.
            if (symbol == 85)
            {
                if (currentString > 0)
                {
                    currentString -= 1;
                    cursorPos = UpdateCursorPosition(cursorPos, result[currentString].Length);
                }
                continue;
            }
            //D нажатие стрелки вниз.
            if (symbol == 68)
            {
                if (currentString < result.Count - 1)
                {
                    currentString += 1;
                    cursorPos = UpdateCursorPosition(cursorPos, result[currentString].Length);
                }
                continue;
            }
            //B нажатие клавиши Home.
            if (symbol == 66)
            {
                cursorPos = 0;
                continue;
            }
            //E нажатие клавиши End.
            if (symbol == 69)
            {
                cursorPos = result[currentString].Length;
                continue;
            }
            //N - нажатие Enter
            if (cursorPos == result[currentString].Length)
            {
                result.Insert(currentString + 1, new StringBuilder());
            }
            else
            {
                var subLength = result[currentString].Length - cursorPos;
                var tmpStr = result[currentString].ToString(cursorPos, subLength);
                result[currentString].Remove(cursorPos, subLength);
                result.Insert(currentString + 1, new StringBuilder(tmpStr));
            }
            cursorPos = 0;
            currentString++;
        }
        result.Add(new StringBuilder("-"));

        return result.Select(x => x.ToString()).ToList();
    }

    private bool IsDigitOrLowerCase(char symbol)
    {
        return (symbol >= 48 && symbol <= 57) || (symbol >= 97 && symbol <= 122);
    }

    private int UpdateCursorPosition(int curPos, int length)
    {
        return curPos > length ? length : curPos;
    }
}