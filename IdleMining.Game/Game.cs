using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IdleMining.Game.Managers;

namespace IdleMining.Game
{
    public interface IGameLoop
    {
        void PreRenderUpdate();
        void PostRenderUpdate();
    }

    public class Game : IGameLoop
    {
        #region DebugInfo
        public int FrameCount { get; set; }
        public List<string> ListenerOnUpdated => Updated?.GetInvocationList()?.Select( x => x.Target.ToString()).ToList();
        #endregion


        public ResourceManager ResourceManager { get; private set; }

        public DwarfManager DwarfManager { get; private set; }
        
        #region GameLoop

        public event EventHandler Updated;
        private CancellationTokenSource cancellationTokenSource;
        private const int TICK_MS_INTERVAL = (1_000 / 5);
        private bool GameStarted = false;

        public async Task StartTickLoop()
        {
            if (GameStarted)
                return;
            GameStarted = true;

            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            var task = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(TICK_MS_INTERVAL);

                    PreRenderUpdate();
                    Updated?.Invoke(this, new EventArgs());
                    PostRenderUpdate();
                }
            }, token);

            await task;
        }

        #endregion

        public void PreRenderUpdate()
        {
            DwarfManager.PreRenderUpdate();
            ResourceManager.PreRenderUpdate();
        }

        public void PostRenderUpdate()
        {
            FrameCount++;

            DwarfManager.PostRenderUpdate();
        }

        public Game()
        {
            ResourceManager = ResourceManager.Instance;
            DwarfManager = DwarfManager.Instance;
        }


        //public void Load(ISyncLocalStorageService localStorage)
        //{

        //}

        //public void Save(ISyncLocalStorageService localStorage)
        //{

        //}

        //public void FullReset(ISyncLocalStorageService localStorage)
        //{

        //    Save(localStorage);
        //}
    }
}
