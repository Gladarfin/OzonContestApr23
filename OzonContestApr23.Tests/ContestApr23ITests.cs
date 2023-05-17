namespace OzonContestApr23.Tests;

public class ContestApr23ITests
{
    [Theory]
    [JsonFileData<ModelI>("tests-i.json")]
    public void ContestApr23ISolve_WithJsonFileData_ShouldReturnsExpectedResult(ModelI model)
    {
        var contestI = new ContestApr23I();

        var result = contestI.Solve(model.TestData);

        Assert.Equal(model.TestAnswer, result);
    }
}