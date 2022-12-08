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

//This is part of a Logger pattern that writes the players loadout to local memory so that it can be loaded later on and
// restored for the player. It directly opens an IO stream so that hard writing may take place every time a save / load 
// command is recieved
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