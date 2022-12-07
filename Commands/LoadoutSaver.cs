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
    public LoadoutLogger logger = new LoadoutLogger();
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

        //equipment is in armor slots 3-7
        logger.WriteLoadout(args[0]);
        
    }
    
}