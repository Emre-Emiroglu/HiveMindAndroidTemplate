using CoreGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Models.CrossScene
{
    public sealed class CrossSceneModel : Model<CrossSceneSettings>
    {
        #region Constructor
        public CrossSceneModel(CrossSceneSettings settings) : base(settings) { }
        #endregion

        #region Executes
        public override void LoadData() { }
        public override void SaveData() { }
        #endregion
    }
}