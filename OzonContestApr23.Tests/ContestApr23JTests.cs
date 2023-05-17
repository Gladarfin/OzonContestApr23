namespace OzonContestApr23.Tests;

public class ContestApr23JTests
{
    [Theory]
    [JsonFileData<ModelJ>("tests-j.json")]
    public void ContestApr23JSolve_WithJsonFileData_ShouldReturnsExpectedResult(ModelJ model)
    {
        var contestJ = new ContestApr23J();

        var result = contestJ.Solve(model.TestData);

        Assert.Equal(model.TestAnswer, result);
    }
}