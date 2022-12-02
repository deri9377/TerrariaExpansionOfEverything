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

namespace TerrariaExpansionOfEverything.Commands;

public class LoadoutSaver : ModCommand
{

    public override CommandType Type 
        => CommandType.World;
    
    public override string Command
        => "saveloadout";

    public override string Usage
        => "/saveloudout loadoutName";

    public override string Description
        => "put in the name of the loadout that you want to save it as";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        
        if (args.Length == 0)
        {
            throw new UsageException("At least one argument was expected.");
        }
        
        String items = "";
        
        //equipment is in armor slots 3-7
        Item[] key = Main.LocalPlayer.armor;
        try
        {
            StreamWriter streamWriter = new StreamWriter($"{args[0]}.txt");
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
        ChatHelper.BroadcastChatMessage(NetworkText.FromKey($"Saved {args[0]}, with items {items}"), Color.Orange);
        
    }
    
}