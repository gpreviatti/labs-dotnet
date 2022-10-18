namespace ReservedKeyWords;
public class InClass
{
    public void CalculateCurrentPriceWithIn(in decimal value, in char type, Account account)
    {
        account.CurrentBalance = type switch
        {
            'E' => account.CurrentBalance - value,
            'I' =>  account.CurrentBalance + value,
            _ =>  account.CurrentBalance + 0
        };
    }
}
