namespace TrafficLighterOnRegister
{
    using System;

    [Flags]
    public enum TrafficLightState
    {
        Red = 0x100,
        Yellow = 0x010,
        Green = 0x001
    }
}
