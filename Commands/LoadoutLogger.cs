using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Net;
using Terraria.Chat;
using Terraria.Localization;
using TerrariaExpansionOfEverything.UI;


namespace TerrariaExpansionOfEverything.Commands
{
    public class LoadoutLogger : ModSystem
    {
        public void WriteLoadout(String loadoutName)
        {
            String items = "";
            Item[] key = Main.LocalPlayer.armor;
            try
            {
                StreamWriter streamWriter = new StreamWriter($"{loadoutName}.txt");
                for (int i = 0; i < key.Length; i++)
                {
                    items += key[i].Name + ", ";
                    streamWriter.WriteLine("" + i + "," + key[i].netID);
                }

                streamWriter.Close();

            }
            catch (Exception e)
            {
                throw new UsageException($"{e.Message}");
            }
            ChatHelper.BroadcastChatMessage(NetworkText.FromKey($"Saved {loadoutName}, with items {items}"), Color.Orange);
        }
    }
} 