using Sandbox;

namespace Nostalgia
{
    public partial class MinimalGame : Game
    {
        public MinimalGame()
        {
            Nostalgia.Start();
        }

        public override void ClientJoined(Client client)
        {
            base.ClientJoined(client);

            var player = new MinimalPlayer();
            client.Pawn = player;

            player.Respawn();
        }
    }
}
