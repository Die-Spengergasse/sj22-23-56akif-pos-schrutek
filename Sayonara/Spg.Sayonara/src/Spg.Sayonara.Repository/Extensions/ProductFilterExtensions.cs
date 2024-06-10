using Spg.Sayonara.DomainModel.Interfaces;

namespace Spg.Sayonara.Repository.Extensions
{
    public static class ProductFilterExtensions
    {
        public static IProductFilterBuilder ApplyDescriptionFilter(this IProductFilterBuilder filter, string description)
        {
            // TODO: LinQ
            return filter;
        }
    }
}
