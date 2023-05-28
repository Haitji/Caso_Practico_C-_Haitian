
using Bootcamp_store_backend.Application;

namespace Bootcamp_store_backend.Infrastructure.Specs
{
    public class SpecificationParser<T> : ISpecificationParser<T>
        where T : class
    {
        Specification<T> ISpecificationParser<T>.ParseSpecification(string filter)
        {
            List<Criterion> criteria = new List<Criterion>();

            var criteriaString = filter.Split(',');
            foreach (var item in criteriaString)
            {
                var parts = item.Split(':');
                if (parts.Length != 3)
                {
                    throw new MalfomedFilterException();
                }

                var criterion = new Criterion
                {
                    Field = Char.ToUpper(parts[0][0]) + parts[0][1..],
                    Operator = parts[1].ToUpper(),
                    Value = parts[2]
                };

                criteria.Add(criterion);
            }

            return new Specification<T>(criteria);
        }
    }
}