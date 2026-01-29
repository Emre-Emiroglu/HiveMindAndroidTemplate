using CoreGameTemplate.Runtime.Enums.CrossScene;
using CoreGameTemplate.Runtime.Models.Bootstrap;
using CoreGameTemplate.Runtime.Signals.Bootstrap;
using CoreGameTemplate.Runtime.Signals.CrossScene;
using CoreGameTemplate.Runtime.Temp;
using Cysharp.Threading.Tasks;

namespace CoreGameTemplate.Runtime.Handlers.Bootstrap
{
    public sealed class BootstrapHandler : SignalListener
    {
        #region ReadonlyFields
        private readonly BootstrapModel _bootstrapModel;
        #endregion

        #region Constructor
        public BootstrapHandler(SignalBus.Runtime.SignalBus signalBus, BootstrapModel bootstrapModel) :
            base(signalBus) => _bootstrapModel = bootstrapModel;
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
                SignalBus.Subscribe<InitializeBootstrapSignal>(OnInitializeBootstrapSignal);
            else
                SignalBus.Unsubscribe<InitializeBootstrapSignal>(OnInitializeBootstrapSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnInitializeBootstrapSignal(InitializeBootstrapSignal signal) => InitializeBootstrap().Forget();
        #endregion
        
        #region Executes
        private async UniTaskVoid InitializeBootstrap()
        {
            int millisecondsDelay = (int)(_bootstrapModel.Settings.SceneActivationDuration * 1000f);
            
            await UniTask.Delay(millisecondsDelay);
            
            SignalBus.Fire(new LoadSceneSignal(SceneID.MainMenu));
        }
        #endregion
    }
}