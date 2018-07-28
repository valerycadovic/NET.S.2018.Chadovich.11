namespace TrafficLightLib
{
    /// <inheritdoc />
    /// <summary>
    /// The green state
    /// </summary>
    /// <seealso cref="T:TrafficLightLib.IState" />
    public class GreenState : IState
    {
        /// <inheritdoc/>
        /// <summary>
        /// Sets the green light and switches lighter to the waiting for yellow state
        /// </summary>
        /// <param name="lighter">The lighter.</param>
        /// <returns>
        /// The current state of lighter as a <see cref="string" />
        /// </returns>
        public string Switch(TrafficLighter lighter)
        {
            lighter.State = new YellowState();
            return "Green";
        }
    }
}
