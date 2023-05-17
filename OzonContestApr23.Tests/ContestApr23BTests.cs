namespace OzonContestApr23.Tests;

public class ContestApr23BTests
{
    [Theory]
    [JsonFileData<ModelB>("tests-b.json")]
    public void ContestApr23BSolve_WithJsonFileData_ShouldReturnsExpectedResult(ModelB model)
    {
        var contestB = new ContestApr23B();

        var result = contestB.Solve(model.TestData);
        
        Assert.Equal(model.TestAnswers, result);
    }
}