namespace Nostalgia.Proxies
{
    /// <summary>
    /// <see cref="Sandbox.Host"/> proxy for testability.
    /// </summary>
    class Host
    {
        /// <summary>
        /// Gets a value indicating whether the execution is going on the client side (player's computer).
        /// </summary>
        public bool IsClient => Sandbox.Host.IsClient;

        /// <summary>
        /// Gets a value indicating whether the execution is going on the server side.
        /// </summary>
        public bool IsServer => Sandbox.Host.IsServer;
    }
}
