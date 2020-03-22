using SMLHelper.V2.Handlers;

namespace Straitjacket.Subnautica.Mods.Debugger
{
    internal class Debugger
    {

        public static Options Options = new Options();
        public static void Initialise()
        {
            OptionsPanelHandler.RegisterModOptions(Options);
        }
    }
}
