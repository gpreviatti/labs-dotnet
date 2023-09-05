using Commons.Models;
using Strategy;
using Strategy.Strategies;

var order = new Order { Value = 100 };

var calculatorIcms = new TaxCalculator(new IcmsTax()).Calcuate(order.Value);
var calculatorIss = new TaxCalculator(new IssTax()).Calcuate(order.Value);

Console.WriteLine(calculatorIcms);
Console.WriteLine(calculatorIss);