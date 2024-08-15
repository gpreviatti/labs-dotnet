using ReservedKeyWords;

namespace Tests.ReservedKeywords;

public class InTest
{
    private readonly InClass _inClass = new();

    [Fact]
    public void Should_Calculate_Income_In_Account_Current_Balance_Without_In_Keyword()
    {
        var value = 100;
        var type = 'I';

        var account = new Account
        {
            CurrentBalance = 100,
            Name = "Checking Account"
        };


        _inClass.CalculateCurrentPriceWithIn(value, type, account);


        Assert.Equal(200, account.CurrentBalance);
    }
}
