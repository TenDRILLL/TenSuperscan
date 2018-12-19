﻿using System;
using LyokoAPI.Events;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace TenSuperscan
{
    class ListenEvent
    {
        public static string Name = "TenSuperscan";
        
        public static void StartSuperscanner()
        {
            TowerActivationEvent.Subscribe(OnTowerActive);
            TowerDeactivationEvent.Subscribe(OnTowerDeactive);
            TowerHijackEvent.Subscribe(OnTowerHijack);
            XanaAwakenEvent.Subscribe(OnXANAWake);
            XanaDefeatEvent.Subscribe(onXANASleep);

        }
        
        public static void StopSuperscanner()
        {
            TowerActivationEvent.UnSubscribe(OnTowerActive);
            TowerDeactivationEvent.UnSubscribe(OnTowerDeactive);
            TowerHijackEvent.Unsubscribe(OnTowerHijack);
            XanaAwakenEvent.Unsubscribe(OnXANAWake);
            XanaDefeatEvent.Unsubscribe(onXANASleep);
        }

        private static void OnTowerActive(ITower tower)
        {
            LyokoLogger.Log(Name,String.Format("Active tower by {0} detected in the {1} region. ({1} - {2})",tower.Activator.ToString().ToUpper(),tower.Sector.Name.ToUpper(),tower.Number));
        }
        
        private static void OnTowerDeactive(ITower tower)
        {
            LyokoLogger.Log(Name,String.Format("Activated tower has been deactivated in the {0} region. ({0} - {1})",tower.Sector.Name.ToUpper(),tower.Number));
        }

        private static void OnTowerHijack(ITower tower, APIActivator oldA, APIActivator newA)
        {
            LyokoLogger.Log(Name,String.Format("A tower in the {0} region has been hijacked by {1} ({0} #{2}: {3}->{1})",tower.Sector.Name.ToUpper(),newA.ToString().ToUpper(),tower.Number,oldA.ToString().ToUpper()));
        }

        private static void OnXANAWake()
        {
            LyokoLogger.Log(Name, "It would seem XANA raises his ugly head once more.");
        }

        private static void onXANASleep()
        {
            LyokoLogger.Log(Name, "RETURN TO THE PAST NOW!!!! (XANA has been defeated)");
        }
    }
}