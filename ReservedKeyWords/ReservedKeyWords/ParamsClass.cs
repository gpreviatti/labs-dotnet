namespace ReservedKeyWords;

public class ParamsClass
{
    public Account[] CreateAccountList(params Account[] list)
    {
        var accounts = new List<Account>();
        foreach (var account in list)
            accounts.Add(account);

        return accounts.ToArray();
    }

    public string[] CreateListFruits(params string[] list)
    {
        var fruits = new string[list.Length];

        for (var i = 0; i < fruits.Length; i++)
            fruits[i] = list[i];
            
        return fruits;
    }
}
