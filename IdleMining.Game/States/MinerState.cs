using System;

namespace IdleMining.Game.States
{
    public class MinerState : BaseState
    {
        public static MinerState Instance { get; } = new MinerState();
        
        public override void OnStateEnter(Dwarf inDwarf)
        {
            Console.WriteLine($"Entering State {nameof(MinerState)}");


        }

        public override void OnStateUpdate(Dwarf inDwarf)
        {

        }

        public override void OnStateLeave(Dwarf inDwarf)
        {
            Console.WriteLine($"Leaving State {nameof(MinerState)}");


        }

        public override string Name()
        {
            return Enum.GetName(typeof(DwarfJob), DwarfJob.Miner);
        }
    }
}
