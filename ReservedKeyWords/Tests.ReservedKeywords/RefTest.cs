using ReservedKeyWords;

namespace Tests.ReservedKeywords;

public class RefTest
{
    private readonly RefClass refClass = new();

    [Fact]
    public void Should_Calculate_Income_With_Ref_Keyword()
    {
        var account = new Account
        {
            CurrentBalance = 100,
            Name = "Checking Account"
        };
        var currentValue = account.CurrentBalance;


        refClass.CalculateCurrentPriceWithRef(200, 'I', ref currentValue);


        Assert.Equal(100, account.CurrentBalance);
        Assert.Equal(300, currentValue);
    }
}
