using System;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.ModLoader;

namespace TerrariaExpansionOfEverything.Commands;
//The commands located in this folder are all part of the command pattern as they are used to execute various functions
// such as setting the players loadout or getting the currently tracked NPC
public class CommandHub : ModCommand
{
    private LoadoutLoader loader;
    private LoadoutSaver saver;
    private NpcCommand npcfinder;

    public override CommandType Type 
        => CommandType.World;
    
    public override string Command
        => "command";

    public override string Usage
        => "/command commandName description";

    public override string Description
        => "put in the name of the loadout that you want to load";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        String commandName = args[0];
        
        if (commandName.Equals("loadloadout"))
        {
            loader = new LoadoutLoader();
            loader.Action(caller, input, new []{args[1]});
        } 
        else if (commandName.Equals("saveloadout"))
        {
            saver = new LoadoutSaver();
            saver.Action(caller, input, new []{args[1]});
        }
        else if (commandName.Equals("findnpc"))
        {
            npcfinder = new NpcCommand();
            npcfinder.Action(caller, input, new []{args[1]});
        }
    }
}