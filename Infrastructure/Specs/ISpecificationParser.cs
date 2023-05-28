using Bootcamp_store_backend.Domain.Entities;

namespace Bootcamp_store_backend.Infrastructure.Specs
{
    public interface ISpecificationParser<T>
    {
        Specification<T> ParseSpecification(string filter);
    }
}