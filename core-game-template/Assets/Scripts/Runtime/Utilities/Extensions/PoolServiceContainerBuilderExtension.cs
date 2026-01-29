using Pool.Runtime;
using VContainer;

namespace CoreGameTemplate.Runtime.Utilities.Extensions
{
    public static class PoolServiceContainerBuilderExtension
    {
        #region Executes
        public static void RegisterPoolService(this IContainerBuilder containerBuilder, PoolConfig poolConfig) =>
            containerBuilder.Register<PoolService>(Lifetime.Singleton).WithParameter(poolConfig).AsSelf();
        #endregion
    }
}