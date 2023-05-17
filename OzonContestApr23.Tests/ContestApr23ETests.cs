namespace OzonContestApr23.Tests;

public class ContestApr23ETests
{
    [Theory]
    [JsonFileData<ModelE>("tests-e.json")]
    public void ContestApr23ESolve_WithJsonFileData_ShouldReturnsExpectedResult(ModelE model)
    {
        var contestE = new ContestApr23E();

        var result = contestE.Solve(model.TestData);

        Assert.Equal(model.TestAnswers, result);
    }
}