using System;

namespace IdleMining.Game.States
{
    public class ScavengerState : BaseState
    {
        public static ScavengerState Instance { get; } = new ScavengerState();

        public override void OnStateEnter(Dwarf inDwarf)
        {
            Console.WriteLine($"Entering State {nameof(ScavengerState)}");


        }

        public override void OnStateUpdate(Dwarf inDwarf)
        {

        }

        public override void OnStateLeave(Dwarf inDwarf)
        {
            Console.WriteLine($"Leaving State {nameof(ScavengerState)}");

        }

        public override string Name()
        {
            return Enum.GetName(typeof(DwarfJob), DwarfJob.Scavenger);
        }
    }
}
