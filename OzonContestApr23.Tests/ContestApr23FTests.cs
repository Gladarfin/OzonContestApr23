namespace OzonContestApr23.Tests;

public class ContestApr23FTests
{
    [Theory]
    [JsonFileData<ModelF>("tests-f.json")]
    public void ContestApr23FSolve_WithJsonFileData_ShouldReturnsExpectedResult(ModelF model)
    {
        var contestF = new ContestApr23F();

        var result = contestF.Solve(model.TestData);

        Assert.Equal(model.TestAnswer, result);
    }
}