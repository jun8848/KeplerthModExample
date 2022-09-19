using Harmony;
using Keplerth;
using System.Reflection;


namespace KeplerthModExample
{
    [StaticConstructorOnStartup]
    public class ModInit
    {
        // Token: 0x06000005 RID: 5 RVA: 0x000020EC File Offset: 0x000002EC
        static ModInit()
        {
            HarmonyInstance harmonyInstance = HarmonyInstance.Create(ModInit.ModName);
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

        // Token: 0x04000002 RID: 2
        public static string ModName = "KeplerthModExample";


        private int GetModHasId()
        {
            return ModName.GetHashCode();
        }
    }
}
