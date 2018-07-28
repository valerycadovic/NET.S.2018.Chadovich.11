namespace TrafficLightLib
{
    /// <summary>
    /// The abstract state. The protocol which describes what transitions do the state machine has
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Switches the specified lighter.
        /// </summary>
        /// <param name="lighter">The lighter.</param>
        /// <returns>The current state of lighter as a <see cref="string"/></returns>
        string Switch(TrafficLighter lighter);
    }
}
