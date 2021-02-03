using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace PingContainer
{
    public class PingResource : AsyncResource
    {
        public static Timer __ResourceInit;
        public override void OnStart()
        {
            __ResourceInit = new Timer(PingTimer.Timer.ResourceInitTimer, null, 3 * 1000, 3 * 1000);
        }
        public override void OnStop() { }
    }
    public class Program : IScript
    {
        public static async void GetClientPing(IPlayer player)
        {
            try
            {
                Ping __PingEntry = new Ping();
                IPAddress __IpGetter = IPAddress.Parse(player?.Ip.Replace("::ffff:", ""));
                PingReply __PingResult = __PingEntry.Send(__IpGetter);

                if (__PingResult.Status == IPStatus.Success)
                    await player.EmitAsync("PingContainer:SendResult", __PingResult.RoundtripTime);
            }
            catch (Exception ex) { PingDebugContainer.Debug.CatchExceptions(ex); }
        }
    }
}
