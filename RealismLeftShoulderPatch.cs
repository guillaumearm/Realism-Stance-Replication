using System.Reflection;
using Fika.Core.Coop.Components;
using Fika.Core.Coop.Players;
using RealismMod;
using SPT.Reflection.Patching;

namespace StanceReplication
{
    public class RealismLeftShoulderPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(StanceController).GetMethod(nameof(StanceController.ToggleLeftShoulder));
        }

        [PatchPostfix]
        public static void Postfix()
        {
            // send packet here
        }
    }
}