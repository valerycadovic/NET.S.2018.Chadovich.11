namespace TrafficLightLib
{
    /// <inheritdoc />
    /// <summary>
    /// The red-yellow state
    /// </summary>
    /// <seealso cref="T:TrafficLightLib.IState" />
    public class RedYellowState : IState
    {
        /// <inheritdoc/>
        /// <summary>
        /// Sets the red-yellow light and switches lighter to the waiting for green state
        /// </summary>
        /// <param name="lighter">The lighter.</param>
        /// <returns>
        /// The current state of lighter as a <see cref="string" />
        /// </returns>
        public string Switch(TrafficLighter lighter)
        {
            lighter.State = new GreenState();
            return "RedYellow";
        }
    }
}
