using LyokoAPI.Events.LWEvents;
using LyokoAPI.RealWorld.Location;
using LyokoAPI.RealWorld.Location.Abstract;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures.Interfaces;

namespace TenSuperscan
{
    public class LyokoWarriorListener
    {
        public static void StartWarriorScan()
        {
            LW_DeathEvent.Subscribe(onLW_Death);
            LW_DevirtEvent.Subscribe(onLW_Devirt);
            LW_VirtEvent.Subscribe(onLW_Virt);
            LW_FrontierEvent.Subscribe(onLW_Frontier);
            LW_HealEvent.Subscribe(onLW_Heal);
            LW_HurtEvent.Subscribe(onLW_Hurt);
            LW_MoveEvent.Subscribe(onLW_Move);
            LW_TranslationEvent.Subscribe(onLW_translation);
            LW_XanaficationEvent.Subscribe(onLW_Xanafication);
        }

        public static void StopWarriorScan()
        {
            LW_DeathEvent.Unsubscribe(onLW_Death);
            LW_DevirtEvent.Unsubscribe(onLW_Devirt);
            LW_FrontierEvent.Unsubscribe(onLW_Frontier);
            LW_HealEvent.Unsubscribe(onLW_Heal);
            LW_HurtEvent.Unsubscribe(onLW_Hurt);
            LW_MoveEvent.Unsubscribe(onLW_Move);
            LW_TranslationEvent.Unsubscribe(onLW_translation);
            LW_XanaficationEvent.Unsubscribe(onLW_Xanafication);
        }

        private static void onLW_Death(LyokoWarrior warrior)
        {
            Main.Log($"{warrior.WarriorName.ToString()} has died!");
        }

        private static void onLW_Devirt(LyokoWarrior warrior)
        {
            Main.Log($"{warrior.WarriorName.ToString()} has been devirtualized!");
        }

        private static void onLW_Frontier(LyokoWarrior warrior)
        {
            Main.Log($"{warrior.WarriorName.ToString()} has been frontiered!");
        }

        private static void onLW_Heal(LyokoWarrior warrior)
        {
            Main.Log($"{warrior.WarriorName.ToString()} has been healed.");
        }

        private static void onLW_Hurt(LyokoWarrior warrior)
        {
            Main.Log($"{warrior.WarriorName.ToString()} has been hurt.");
        }

        private static void onLW_Move(LyokoWarrior warrior)
        {
            Main.Log($"{warrior.WarriorName.ToString()} has moved to {warrior.Location.GetLocationName()}");
        }

        private static void onLW_translation(LyokoWarrior warrior)
        {
            Main.Log($"{warrior.WarriorName.ToString()} has been translated to {warrior.Location.GetLocationName()}");
        }

        private static void onLW_Virt(LyokoWarrior warrior)
        {
            Main.Log($"{warrior.WarriorName.ToString()} has virtualized to {warrior.Location.GetLocationName()}");

        }

        private static void onLW_Xanafication(LyokoWarrior warrior)
        {
            Main.Log($"{warrior.WarriorName.ToString()} has been xanafied!");
        }
        
        
    }
}