

using TMP.aplication.response.db;

namespace TMP.domain.contracts.useCase
{
    public interface IUseCaseVoid<k>
    {
        public Task<k> Execute();
    }
}
