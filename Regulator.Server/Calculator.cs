namespace Regulator.Server;

public class Calculator
{
    public double Calculate(double a, double b)
    {
        try
        {
            return a + b;
        }
        catch (OverflowException e)
        {

        }
    }
}
