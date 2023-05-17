namespace OzonContestApr23.Tests;

public class ContestApr23DTests
{
    [Theory]
    [JsonFileData<ModelD>("tests-d.json")]
    public void ContestApr23DSolve_WithJsonFileData_ShouldReturnsExpectedResult(ModelD model)
    {
        var contestD = new ContestApr23D();

        var result = contestD.Solve(model.TestData);

        Assert.Equal(model.TestAnswer, result);
    }
}