

using TMP.aplication.response.db;

namespace TMP.domain.contracts.useCase
{
    public interface IUseCase<T, K>
    {
        public Task<K> Execute(T options);
    }
}
