using CoreGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Models.Bootstrap
{
    public sealed class BootstrapModel : Model<BootstrapSettings>
    {
        #region Constructor
        public BootstrapModel(BootstrapSettings settings) : base(settings) { }
        #endregion

        #region Executes
        public override void LoadData() { }
        public override void SaveData() { }
        #endregion
    }
}
