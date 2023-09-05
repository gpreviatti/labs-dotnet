using Strategy.Interface;

namespace Strategy.Strategies;

public class IssTax : ITax
{
    public float Calculate(float value) => value * 0.1f;
}