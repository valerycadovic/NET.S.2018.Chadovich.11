namespace TrafficLightLib
{
    using System;

    /// <summary>
    /// Traffic lighter final state machine
    /// </summary>
    public class TrafficLighter
    {
        /// <summary>
        /// The state
        /// </summary>
        private IState state;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrafficLighter"/> class.
        /// </summary>
        /// <param name="state">The start state.</param>
        /// <exception cref="System.ArgumentNullException">Throws when the start state is null</exception>
        public TrafficLighter(IState state)
        {
            this.State = state ?? throw new ArgumentNullException($"{nameof(state)} is null");
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        /// <exception cref="System.ArgumentNullException">Throws when value is null</exception>
        public IState State
        {
            get => this.state;
            set => this.state = value ?? throw new ArgumentNullException($"{nameof(value)} is null");
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get; private set; }

        /// <summary>
        /// Switches this instance.
        /// </summary>
        public void Switch()
        {
            this.Color = this.State.Switch(this);
        }
    }
}
