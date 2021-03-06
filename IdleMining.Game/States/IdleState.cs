using System;

namespace IdleMining.Game.States
{
    public class IdleState : BaseState
    {
        public override void OnStateEnter(Dwarf inDwarf)
        {
            Console.WriteLine($"Entering State {nameof(IdleState)}");

        }

        public static IdleState Instance { get; } = new IdleState();

        public override void OnStateUpdate(Dwarf inDwarf)
        {

        }

        public override void OnStateLeave(Dwarf inDwarf)
        {
            Console.WriteLine($"Leaving State {nameof(IdleState)}");
        }

        public override string Name()
        {
            return Enum.GetName(typeof(DwarfJob), DwarfJob.Idle);
        }
    }
}