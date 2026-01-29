using System.Collections.Generic;
using CoreGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CoreGameTemplate.Runtime.Enums.CrossScene;
using CoreGameTemplate.Runtime.Models.CrossScene;
using CoreGameTemplate.Runtime.Views.CrossScene;
using ModelViewMediatorController.Runtime;
using Utilities.Runtime;

namespace CoreGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class CurrencyDisplayController : Controller<CurrencyModel, CurrencySettings, CurrencyView>
    {
        #region Constructor
        public CurrencyDisplayController(CurrencyModel model, CurrencyView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            CurrencyTypes currencyType = (CurrencyTypes) parameters[0];
            bool all = (bool) parameters[1];

            if (all)
                foreach (KeyValuePair<CurrencyTypes, int> modelCurrencyValue in Model.CurrencyPersistentData
                             .CurrencyValues)
                    RefreshCurrencyVisual(modelCurrencyValue.Key);
            else
                RefreshCurrencyVisual(currencyType);
        }
        private void RefreshCurrencyVisual(CurrencyTypes currencyType)
        {
            int value = Model.CurrencyPersistentData.CurrencyValues[currencyType];

            View.CurrencyTexts[currencyType].SetText(TextFormatter.FormatNumber(value));
        }
        #endregion
    }
}