using CoreGameTemplate.Runtime.Data.ScriptableObjects.Application;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Models.Application
{
    public sealed class ApplicationModel : Model<ApplicationSettings>
    {
        #region Constructor
        public ApplicationModel(ApplicationSettings settings) : base(settings) { }
        #endregion
        
        #region Executes
        public override void LoadData() { }
        public override void SaveData() { }
        #endregion
    }
}
