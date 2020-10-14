using ExitGames.Client.Photon;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TheBotUI;

public static class PhotonExtensions
{
    public static string GetUsername(this Player player)
    {
        if (player.CustomProperties.ContainsKey("user"))
            if (player.CustomProperties["user"] is Dictionary<string, object> dict)
                return (string)dict["username"];
        return "";
    }
    public static string GetUserID(this Player player)
    {
        if (player.CustomProperties.ContainsKey("user"))
            if (player.CustomProperties["user"] is Dictionary<string, object> dict)
                return (string)dict["id"];
        return "";
    }

    public static string GetDisplayName(this Player player)
    {
        if (player.CustomProperties.ContainsKey("user"))
            if (player.CustomProperties["user"] is Dictionary<string, object> dict)
                return (string)dict["displayName"];
        return "";
    }
    public static string GetSteamID(this Player player)
    {
        if (player.CustomProperties.ContainsKey("steamUserID"))
            if((string)player.CustomProperties["steamUserID"] != "0")
                return (string)player.CustomProperties["steamUserID"];
        return "No Steam";
    }
    public static void EventSpammer(this int count, int amount, Action action,int? sleep = null)
    {
        for (int ii = 0; ii < count; ii++)
        {
            for (int i = 0; i < amount; i++)
                action();
            if (sleep != null)
                Thread.Sleep(sleep.Value);
            else
                Thread.Sleep(25);
        }
    }
    public static Player GetPlayer(int PhotonID)
    {
        var bot = Form1.selectedBot;
        foreach (var item in bot.PhotonClient.CurrentRoom.Players)
        {
            if (item.Value.ActorNumber == PhotonID)
            {
                return item.Value;
            }
        }
        return null;
    }
    public static RaiseEventOptions SetPlayerAsTarget(Player ply)
    {
        return new RaiseEventOptions
        {
            TargetActors = new int[] { ply.ActorNumber }
        };
    }
}
