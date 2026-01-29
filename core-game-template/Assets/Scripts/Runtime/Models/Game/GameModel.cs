using CoreGameTemplate.Runtime.Data.ScriptableObjects.Game;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Models.Game
{
    public sealed class GameModel : Model<GameSettings>
    {
        #region Constructor
        public GameModel(GameSettings settings) : base(settings) { }
        #endregion

        #region Executes
        public override void LoadData() { }
        public override void SaveData() { }
        #endregion
    }
}