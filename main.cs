using LyokoAPI.Events;
using LyokoAPI.Plugin;

namespace TenSuperscan
{
    public class Main : LyokoAPIPlugin
    { 
        public override string Author { get; } = "TenDRILLL";
        public override string Name { get; } = "TenSuperscan";
        protected override bool OnDisable()
        {
            ListenEvent.StopSuperscanner();
            return true;
        }

        protected override bool OnEnable()
        {
            ListenEvent.StartSuperscanner();
            return true;
        }

        public override void OnGameEnd(bool failed)
        {
            Enable();
            LyokoLogger.Log(Name,"Game end event detected.");
        }

        public override void OnGameStart(bool storyMode)
        {
            if (storyMode)
            {
                LyokoLogger.Log(Name,"Storymode started. TenSuperscan is disabled. The plugin will be re-enabled once you return to the menu.");
                Disable();
            }
            LyokoLogger.Log(Name,"Game start event detected.");
        }
    }
}