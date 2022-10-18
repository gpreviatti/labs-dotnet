using ReservedKeyWords;

namespace Tests.ReservedKeywords;

public class OutTest
{
    private readonly OutClass outClass = new();

    [Fact]
    public void Should_Sum_Variables_Value_With_Out_Keyword()
    {
        var number1 = 10;
        var number2 = 20;
        var sum = 0;


        outClass.Sum(number1, number2, out sum);

        Assert.Equal(number1 + number2, sum);
    }

    [Fact]
    public void Should_Not_Times_Variables_Value_Without_Out_Keyword()
    {
        var number1 = 10;
        var number2 = 20;
        var result = 0;


        outClass.Times(number1, number2, result);

        
        Assert.NotEqual(number1 * number2, result);
    }


    [Fact]
    public void Should_Calculate_Income_In_Account_Current_Balance_Without_Out_Keyword()
    {
        var account = new Account
        {
            CurrentBalance = 100,
            Name = "Checking Account"
        };


        outClass.CalculateCurrentPrice(account, 100, 'I');


        Assert.Equal(200, account.CurrentBalance);
    }
}
