﻿namespace TrafficLightLib
{
    /// <inheritdoc />
    /// <summary>
    /// The red state of the lighter
    /// </summary>
    /// <seealso cref="T:TrafficLightLib.IState" />
    public class RedState : IState
    {
        /// <inheritdoc/>
        /// <summary>
        /// Sets the red light and switches lighter to the waiting for red-yellow state
        /// </summary>
        /// <param name="lighter">The lighter.</param>
        /// <returns>
        /// The current state of lighter as a <see cref="string" />
        /// </returns>
        public string Switch(TrafficLighter lighter)
        {
            lighter.State = new RedYellowState();
            return "Red";
        }
    }
}
