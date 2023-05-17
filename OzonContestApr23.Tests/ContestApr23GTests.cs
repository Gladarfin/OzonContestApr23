namespace OzonContestApr23.Tests;

public class ContestApr23GTests
{
    [Theory]
    [JsonFileData<ModelG>("tests-g.json")]
    public void ContestApr23GSolve_WithJsonFileData_ShouldReturnsExpectedResult(ModelG model)
    {
        var contestG = new ContestApr23G();

        var result = contestG.Solve(model.TestData);

        Assert.Equal(model.TestAnswer, result);
    }
}