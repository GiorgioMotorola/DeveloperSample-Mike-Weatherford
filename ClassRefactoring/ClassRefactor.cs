using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, 
        European
    }

    public enum SwallowLoad
    {
        None, 
        Coconut
    }


    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType)
        {
            return new Swallow(swallowType);
        }
    }


    public class Swallow
    {

        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        private static readonly Dictionary<(SwallowType, SwallowLoad), double> AirspeedVelocities = new Dictionary<(SwallowType, SwallowLoad), double>
        {
            {(SwallowType.African, SwallowLoad.None), 22},
            {(SwallowType.African, SwallowLoad.Coconut), 18},
            {(SwallowType.European, SwallowLoad.None), 20},
            {(SwallowType.European, SwallowLoad.Coconut), 16}
        };

        public double GetAirspeedVelocity()
        {
            if (AirspeedVelocities.TryGetValue((Type, Load), out var velocity))
            {
                return velocity;
            }

            throw new InvalidOperationException();
        }
    }
}