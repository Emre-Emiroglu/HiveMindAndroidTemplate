using AYellowpaper.SerializedCollections;
using CoreGameTemplate.Runtime.Enums.CrossScene;
using UnityEngine;

namespace CoreGameTemplate.Runtime.Data.ScriptableObjects.CrossScene
{
    [CreateAssetMenu(fileName = "CurrencySettings", menuName = "CoreGameTemplate/CrossScene/CurrencySettings")]
    public sealed class CurrencySettings : ScriptableObject
    {
        #region Fields
        [Header("Currency Settings Fields")]
        [SerializeField] private SerializedDictionary<CurrencyTypes, int> defaultCurrencyValues;
        #endregion

        #region Getters
        public SerializedDictionary<CurrencyTypes, int> DefaultCurrencyValues => defaultCurrencyValues;
        #endregion
    }
}
