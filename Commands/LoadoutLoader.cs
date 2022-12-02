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

public class LoadoutLoader : ModCommand
{

    public override CommandType Type 
        => CommandType.World;
    
    public override string Command
        => "loadloadout";

    public override string Usage
        => "/loadloadout loadoutName";

    public override string Description
        => "put in the name of the loadout that you want to load";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        
        if (args.Length == 0)
        {
            throw new UsageException("At least one argument was expected.");
        }
        
        try
        {
            StreamReader sr = new StreamReader($"{args[0]}.txt");
            String line = sr.ReadLine();
            while (line != null)
            {
                string[] text = line.Split(',');
                int slot = Int32.Parse(text[0]);
                int id = Int32.Parse(text[1]);
                Main.LocalPlayer.armor[slot] = new Item(id);
                line = sr.ReadLine();
            }

        }
        catch (Exception e)
        {
            throw new UsageException($"{e.Message}");
        }
        
        ChatHelper.BroadcastChatMessage(NetworkText.FromKey($"Loaded {args[0]} equipment loadout"), Color.Orange);
        
    }
    
}