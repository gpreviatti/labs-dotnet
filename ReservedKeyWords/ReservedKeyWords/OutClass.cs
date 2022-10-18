namespace ReservedKeyWords;
public class OutClass
{
    public void Sum(int number1, int number2, out int result) => result = number1 + number2;

    public void Times(int number1, int number2, int result) => result = number1 * number2;


    public void CalculateCurrentPrice(Account account, decimal value, char type)
    {
        account.CurrentBalance = type switch
        {
            'E' => account.CurrentBalance - value,
            'I' => account.CurrentBalance + value,
            _ => account.CurrentBalance + 0
        };
    }
}
