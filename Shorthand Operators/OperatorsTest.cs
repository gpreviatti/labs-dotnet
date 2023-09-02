namespace ShorthandOperators;

public class OperatorsTest
{
    /// <summary>
    /// Or, the Ternary Operator, it is a shortened and a cleaner way to write if-else statement.
    /// </summary>
    [Fact]
    public void Conditional()
    {
        var number = 10;
            
        Assert.True(number == 10 ? true : false);
    }
    
    /// <summary>
    /// Existing since C# 2, it is used to combine the value of an operand with null to generate one value,
    /// which is either the value of the left-hand operand if it is not null, or it is the value of the
    /// right-hand operand otherwise.
    /// </summary>
    [Fact]
    public void NullCoalescing()
    {
        string? firstName = null;
    
        var result = firstName ?? "Giovanni"; 
            
        Assert.Equal("Giovanni", result);
    }
    
    /// <summary>
    /// The order of execution is done from right to left, this is a very clean way to return a default
    /// value if there are multiple null reference types, on the same line
    /// </summary>
    [Fact]
    public void ChainedNullCoalescing()
    {
        string? firstName = null;
        string? lastName = null;
    
        var result = lastName ?? firstName ?? "Giovanni Previatti";

        Assert.Equal("Giovanni Previatti", result);
    }
}