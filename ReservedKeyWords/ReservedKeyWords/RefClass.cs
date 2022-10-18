namespace ReservedKeyWords;

public class RefClass
{
    public void CalculateCurrentPriceWithRef(decimal value, char type, ref decimal currentBalance)
    {
        currentBalance = type switch
        {
            'E' => currentBalance - value,
            'I' => currentBalance + value,
            _ => currentBalance + 0
        };
    }
}
