using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using System;

namespace SCPBreachBroadcast
{
    public class SCPBreachBroadcast
    {
        public static SCPBreachBroadcast Instance { get; private set; }

        [PluginEntryPoint("SCPBreachBroadcast", "1.0.0", "A plugin that automatically broadcasts a message about breach", "HAHOOS")]
        void LoadPlugin()
        {
            Instance = this;
            EventManager.RegisterEvents<EventHandlers>(this);

            var handler = PluginHandler.Get(this);
        }
    }
}