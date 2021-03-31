using System;

namespace IdleMining.Game.States
{
    public abstract class BaseState
    {
        public enum DwarfJob
        {
            Idle,
            Woodcutter,
            Miner,
            Scavenger
        }

        public static BaseState GetState(string inState)
        {
            return GetState((DwarfJob)Enum.Parse(typeof(DwarfJob), inState));
        }

        public static BaseState GetState(DwarfJob inState)
        {
            switch (inState)
            {
                case DwarfJob.Woodcutter:
                    return WoodcutterState.Instance;
                case DwarfJob.Idle:
                    return IdleState.Instance;
                case DwarfJob.Miner:
                    return MinerState.Instance;
                case DwarfJob.Scavenger:
                    return ScavengerState.Instance;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inState), inState, null);
            }
        }

        public abstract void OnStateEnter(Dwarf inDwarf);

        public abstract void OnStateUpdate(Dwarf inDwarf);

        public abstract void OnStateLeave(Dwarf inDwarf);

        public abstract string Name();
    }
}