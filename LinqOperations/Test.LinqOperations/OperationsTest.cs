namespace Test.LinqOperations;

public class OperationsTest
{
    private List<Person> _person = new();

    [Fact]
    public void Should_Test_FirstOrDefaultOperation_Return_Null()
    {
        var result = _person.FirstOrDefault();
        
        Assert.Null(result);
    }
    
    [Fact]
    public void Should_Test_FirstOperation_Throw_NullException()
    {
        Assert.Throws<InvalidOperationException>(() => _person.First());
    }
    
    [Fact]
    public void Should_Test_SingleOrDefaultOperation_Return_Null()
    {
        var result = _person.SingleOrDefault();
        
        Assert.Null(result);
    }
    
    [Fact]
    public void Should_Test_SingleOperation_Throw_NullException()
    {
        Assert.Throws<InvalidOperationException>(() => _person.Single());
    }
}