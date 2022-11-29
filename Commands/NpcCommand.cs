using System;
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

public class NpcCommand : ModCommand
{

    public override CommandType Type 
        => CommandType.World;
    
    public override string Command
        => "findnpc";

    public override string Usage
        => "/findnpc npcName";

    public override string Description
        => "put in a the name of the npc you want to fine";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        if (args.Length == 0)
        {
            throw new UsageException("At least one argument was expected.");
        }

        if (!int.TryParse(args[0], out int type))
        {
            throw new UsageException(args[0] + " is not a correct integer value.");
        }

        NPC npc = null; 
        NPC[] list = Main.npc;
        Vector2 position = new Vector2();
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].type == type)
            {
                npc = list[i];
                position = list[i].position;
                break;
            }
        }
        string key = $"The position of the npc: {npc.type} is x: {position.X}, y: {position.Y}";
        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(key), Color.Orange);
        ModContent.GetInstance<NPCFinderMod>().setNPC(npc);
        

    }
    
}