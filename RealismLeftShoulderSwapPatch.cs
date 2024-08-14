using System.Reflection;
using Comfort.Common;
using Fika.Core.Coop.Components;
using Fika.Core.Coop.GameMode;
using Fika.Core.Coop.Players;
using Fika.Core.Coop.Utils;
using Fika.Core.Networking;
using LiteNetLib;
using LiteNetLib.Utils;
using RealismMod;
using SPT.Reflection.Patching;

namespace StanceReplication
{
    public class RealismLeftShoulderSwapPatch : ModulePatch
    {
        public static NetDataWriter writer;
        protected override MethodBase GetTargetMethod()
        {
            return typeof(StanceController).GetMethod(nameof(StanceController.ToggleLeftShoulder));
        }

        [PatchPostfix]
        public static void Postfix()
        {
            CoopHandler fikaCoopHandler;
            if (CoopHandler.TryGetCoopHandler(out fikaCoopHandler))
            {
                fikaCoopHandler.MyPlayer.PacketSender.FirearmPackets.Enqueue(new WeaponPacket()
                {
                    HasStanceChange = true,  
                    LeftStanceState = StanceController.IsLeftShoulder
                });
            }
        }
    }
}