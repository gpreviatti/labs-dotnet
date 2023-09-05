using Strategy.Interface;

namespace Strategy.Strategies;

public class IcmsTax : ITax
{
    public float Calculate(float value) => value * 0.5f;
}