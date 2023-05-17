namespace OzonContestApr23.Tests;

public class ContestApr23HTests
{
    [Theory]
    [JsonFileData<ModelH>("tests-h.json")]
    public void ContestApr23HSolve_WithJsonFileData_ShouldReturnsExpectedResult(ModelH model)
    {
        var contH = new ContestApr23H();
        var result = contH.Solve(model.TestData);

        Assert.Equal(model.TestAnswer,result);
    }
}