using ReservedKeyWords;

namespace Tests.ReservedKeywords;

public class ParamsTest
{
    private readonly ParamsClass paramsClass = new();

    [Fact]
    public void Should_Create_Accounts_List_With_Params()
    {
        var result = paramsClass.CreateAccountList(new Account(), new Account());

        
        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void Should_Create_Fruit_List_With_Params()
    {
        var result = paramsClass.CreateListFruits("Apple", "Avocado", "PineApple", "Bananas");


        Assert.Equal(4, result.Length);
    }
}
