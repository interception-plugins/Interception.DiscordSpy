using System;
using System.Collections.Generic;

using Steamworks;

using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using Rocket.API.Collections;

using interception.enums;
using interception.discord;
using interception.discord.types;
using interception.serialization.types.discord;

namespace interception.plugins.discordspy {   
    public class spy_player_component : UnturnedPlayerComponent {
        void on_spy_ready(CSteamID steamID, byte[] data) {
            var wh = (webhook)main.cfg.webhook_settings;
            wh.content = main.instance.Translate("on_spy", base.Player.CharacterName, base.Player.CSteamID.m_SteamID);
            wh.add_file(data, $"spy_{steamID.m_SteamID}.png");
            webhook_manager.send_webhook_async_unsafe(main.cfg.webhook_url, wh);
        }

        protected override void Load() {
            base.Player.Player.onPlayerSpyReady += on_spy_ready;
        }

        protected override void Unload() {
            base.Player.Player.onPlayerSpyReady -= on_spy_ready;
        }
    }
    
    public class config : IRocketPluginConfiguration, IDefaultable {
        public string webhook_url;
        public s_webhook webhook_settings;
       
        public void LoadDefaults() {
            webhook_url = "0_o";
            webhook_settings = new s_webhook() { 
                username = "Interception's Unturned Spy Bot",
                avatar_url = "https://avatars.akamai.steamstatic.com/08c9944b3176faed9e762311495d14e2860a538a_full.jpg",
                flags = new List<e_webhook_flag>() { 
                    e_webhook_flag.suppress_notifications
                }
            };
        }
    }

    public class main : RocketPlugin<config> {
        internal static main instance;
        internal static config cfg;

        protected override void Load() {
            instance = this;
            cfg = instance.Configuration.Instance;
            GC.Collect();
        }

        protected override void Unload() {
            cfg = null;
            instance = null;
            GC.Collect();
        }

        public override TranslationList DefaultTranslations => new TranslationList
        {
            { "on_spy", "Screenshot for player \"{0}\" [{1}]" }
        };
    }
}

