static async Task<int> Sum()
{
    await Task.Delay(5000);

    return 10;
}

var number1 = Sum();
var number2 = Sum();

await Task.WhenAll(number1, number2);

Console.WriteLine(number1.Result + number2.Result);