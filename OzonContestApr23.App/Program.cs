using System.Diagnostics;
using Newtonsoft.Json;
using OzonContestApr23.App.Models;
using OzonContestApr23.App.Solutions;

//менять на то, которое хотим тестировать ContestApr23B, ContestApr23C, etc.
var cont = new ContestApr23J();

var tmp = AppDomain.CurrentDomain.BaseDirectory;
//файл с тестом
var curTestFile = "tests-j.json";
var path = Path.GetFullPath(Path.Combine(tmp, $@"..\..\..\..\TestsInJson\{curTestFile}"));
var data = File.ReadAllText(path);
//указывать модель
var json = JsonConvert.DeserializeObject<List<ModelJ>>(data);
var timeMemory = new List<TimeAndMemoryModel>();
var i = 1;
foreach (var model in json)
{
        var sw = Stopwatch.StartNew();
        var memBefore = GC.GetAllocatedBytesForCurrentThread();
        if (model.TestNumber == 1235)
        {
            i++;
            sw.Stop();
            Console.WriteLine($"Current test: {i}");
            continue;
        }
            
        cont.Solve(model.TestData);
        var memAfter = GC.GetAllocatedBytesForCurrentThread();
        var memAllocTotal = memAfter - memBefore;
        sw.Stop();
        timeMemory.Add(new TimeAndMemoryModel {
            TestNumber = i, 
            ElapsedTime = sw.Elapsed.TotalSeconds, 
            MemoryAllocatedBytes = memAllocTotal });
        Console.WriteLine($"Current test: {i}");
        i++;
}

var output = JsonConvert.SerializeObject(timeMemory, Formatting.Indented);
//путь куда сохранять результаты замеров для тестов
var filename = "timeAndMemoryForJ.json";
var saveTo = Path.GetFullPath(Path.Combine(tmp, $@"..\..\..\..\TestsInJson\ElapsedTimeAndMemoryForEachTestCase\{filename}"));
File.WriteAllText(saveTo, output);

