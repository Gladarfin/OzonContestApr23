namespace OzonContestApr23.Tests;

public class ContestApr23CTests
{
    [Theory]
    [JsonFileData<ModelC>("tests-c.json")]
    public void ContestApr23CSolve_WithJsonFileData_ShouldReturnsExpectedResult(ModelC model)
    {
        var contestC = new ContestApr23C();

        var result = contestC.Solve(model.TestData);
        
        Assert.Equal(model.TestAnswer, result);
    }
}