using System;

namespace IdleMining.Game.States
{
    public class WoodcutterState : BaseState
    {
        public static WoodcutterState Instance { get; } = new WoodcutterState();
        
        public override void OnStateEnter(Dwarf inDwarf)
        {
            Console.WriteLine($"Entering State {nameof(WoodcutterState)}");

        }

        public override void OnStateUpdate(Dwarf inDwarf)
        {

        }

        public override void OnStateLeave(Dwarf inDwarf)
        {
            Console.WriteLine($"Leaving State {nameof(WoodcutterState)}");

        }

        public override string Name()
        {
            return Enum.GetName(typeof(DwarfJob), DwarfJob.Woodcutter);
        }
    }
}
