using System;
using System.Collections.Generic;
using System.Xml;
using LyokoAPI.API;
using LyokoAPI.API.Compatibility;
using LyokoAPI.Events;
using LyokoAPI.Plugin;

namespace TenSuperscan
{
    public class Main : LyokoAPIPlugin
    {
        public override string Author { get; } = "TenDRILLL";
      

        public override string Name { get; } = "TenSuperscan";
        public override LVersion Version { get; } = LVersion.Parse("2.0.0.0");
        public override List<LVersion> CompatibleLAPIVersions { get; } = new List<LVersion>() {"2.0.0"};

        protected override bool OnDisable()
        {
            SuperscanListener.StopSuperscanner();
            LyokoWarriorListener.StopWarriorScan();
            return true;
        }

        protected override bool OnEnable()
        {
            SuperscanListener.StartSuperscanner();
            LyokoWarriorListener.StartWarriorScan();
            return true;
        }

        public override void OnGameEnd(bool failed)
        {
            Enable();
            LyokoLogger.Log(Name,"Game end event detected.");
        }

        public override void OnInterfaceExit()
        {
            LyokoLogger.Log(Name,"you stepped away from the interface");
        }
        public override void OnInterfaceEnter()
        {
            LyokoLogger.Log(Name,"you entered the interface");
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




        public static void Log(string message)
        {
            LyokoLogger.Log("TenSuperscan", message);
        }
    }
}