using AltV.Net.Elements.Entities;
using System;
using System.Linq;

namespace PingTimer
{
    public class Timer
    {
        public static void ResourceInitTimer(Object __call)
        {
            try
            {
                foreach (IPlayer _Entry in AltV.Net.Alt.GetAllPlayers().ToList())
                    if (_Entry is not null && _Entry.Exists) PingContainer.Program.GetClientPing(_Entry);
            }
            catch (Exception ex) { PingDebugContainer.Debug.CatchExceptions(ex); }
        }
    }
}
