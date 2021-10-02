using Sandbox;
using Sandbox.UI;

namespace Nostalgia
{
    public partial class MinimalHudEntity : HudEntity<RootPanel>
    {
        public MinimalHudEntity()
        {
            if (IsClient)
            {
                RootPanel.SetTemplate("/minimalhud.html");
            }
        }
    }
}
