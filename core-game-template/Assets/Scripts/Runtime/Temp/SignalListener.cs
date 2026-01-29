using CoreGameTemplate.Runtime.Interfaces;

namespace CoreGameTemplate.Runtime.Temp
{
    public abstract class SignalListener : ISignalListenable
    {
        #region ReadonlyFields
        protected readonly SignalBus.Runtime.SignalBus SignalBus;
        #endregion

        #region Constructor
        protected SignalListener(SignalBus.Runtime.SignalBus signalBus) => SignalBus = signalBus;
        #endregion

        #region Core
        public virtual void Initialize() => SetSubscriptions(true);
        public virtual void Dispose() => SetSubscriptions(false);
        protected abstract void SetSubscriptions(bool isSubscribed);
        #endregion
    }
}