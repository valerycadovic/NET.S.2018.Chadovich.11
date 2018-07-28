namespace TrafficLightLib
{
    /// <inheritdoc />
    /// <summary>
    /// The Yellow state
    /// </summary>
    /// <seealso cref="T:TrafficLightLib.IState" />
    public class YellowState : IState
    {
        /// <inheritdoc/>
        /// <summary>
        /// Sets the yellow light and switches lighter to the waiting for red state
        /// </summary>
        /// <param name="lighter">The lighter.</param>
        /// <returns>
        /// The current state of lighter as a <see cref="string" />
        /// </returns>
        public string Switch(TrafficLighter lighter)
        {
            lighter.State = new RedState();
            return "Yellow";
        }
    }
}
