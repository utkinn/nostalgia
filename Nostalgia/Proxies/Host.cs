namespace Nostalgia.Proxies
{
    internal class Host
    {
        public bool IsClient => Sandbox.Host.IsClient;

        public bool IsServer => Sandbox.Host.IsServer;
    }
}
