using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using System.Threading.Tasks;

namespace SCPBreachBroadcast
{
    internal class EventHandlers
    {
        [PluginEvent(ServerEventType.RoundStart)]
        public async void RoundStarted()
        {
            await Task.Delay(1000);
            string scps_string = "";
            foreach (var player in Player.GetPlayers())
            {
                Log.Info($"{player.Nickname}: {player.Role.ToString()}");
                if (player.Role.ToString().Contains("Scp"))
                {
                    if (scps_string == "")
                    {
                        scps_string += player.Role.ToString().ToUpper().Replace("P", "P ") + " ";
                    }
                    else
                    {
                        scps_string += " " + player.Role.ToString().ToUpper().Replace("P", "P ") + " ";
                    }
                }
            }
            if (scps_string != "")
            {
                Cassie.Message(scps_string + " have breached containment . All personel are advised to proceed with standard evacuation protocols", isSubtitles: true, isNoisy: true);
            }
            else if (scps_string == "")
            {
                Cassie.Message("The facility has been scanned . . 0 breaches detected . . Substantial threat to safety remains within the facility -- exercise caution", isSubtitles: true);
            }
        }

        [PluginEvent(ServerEventType.PlayerChangeRole)]
        public void PlayerChangeRole(Player player)
        {
            Log.Info(player.Role.ToString());
        }
    }
}
