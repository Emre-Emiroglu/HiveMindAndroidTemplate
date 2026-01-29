using System.Collections.Generic;
using CoreGameTemplate.Runtime.Enums.CrossScene;

namespace CoreGameTemplate.Runtime.Data.ValueObjects.CrossScene
{
    public struct CurrencyPersistentData
    {
        #region Fields
        public readonly Dictionary<CurrencyTypes, int> CurrencyValues;
        #endregion

        #region Constructor
        public CurrencyPersistentData(Dictionary<CurrencyTypes, int> currencyValues) => CurrencyValues = currencyValues;
        #endregion
    }
}