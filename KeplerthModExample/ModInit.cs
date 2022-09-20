using Harmony;
using Keplerth;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;


namespace KeplerthModExample
{
    [StaticConstructorOnStartup]
    public class ModInit
    {
        // MOD名称
        public static string ModName = "KeplerthModExample";

        static ModInit()
        {
            HarmonyInstance harmonyInstance = HarmonyInstance.Create(ModInit.ModName);
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

        public static int GetModHasId()
        {
            return ModName.GetHashCode();
        }

        // 初始化XML文件
        private void InitXml()
        {
            string gamePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string modInfoPath = gamePath + "\\Keplerth_Data\\StreamingAssets\\Mods\\" + ModInit.ModName + "\\ModIni\\";
            if (!Directory.Exists(modInfoPath))
            {
                Directory.CreateDirectory(modInfoPath);
                XmlFile xml = new XmlFile();
                xml.InitXml(modInfoPath);
            }
        }
    }
}
