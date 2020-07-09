using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqHomework
{
    public class ProductClassHomework
    {
        public List<ProductWithFeatures> products;

        public ProductClassHomework(List<ProductWithFeatures> list)
        {
            this.products = list;
        }

        public List<ProductWithFeatures> ProductsWithAtLeastOneFeatureFromTheList(ICollection<Feature> features)
        {
            Func<ProductWithFeatures, bool> doesItHaveTheFeatures = x =>
            {
                FeatureComparer comparer = new FeatureComparer();
                bool b = x.Features.Any(y => features.Contains(y, comparer));
                return b;
            };

            return products.Where(doesItHaveTheFeatures).ToList();
        }

        public List<ProductWithFeatures> ProductsWithAllTheFeaturesFromTheList(ICollection<Feature> features)
        {
            Func<ProductWithFeatures, bool> doesItHaveAllTheFeatures = x =>
            {
                FeatureComparer comparer = new FeatureComparer();
                bool b = features.Aggregate(0, (total, y) => x.Features.Contains(y, comparer) == true ? total + 1 : total) == features.Count;
                return b;
            };

            return products.Where(doesItHaveAllTheFeatures).ToList();
        }

        public List<ProductWithFeatures> ProductsWithNoneOfTheFeaturesFromTheList(ICollection<Feature> features)
        {
            Func<ProductWithFeatures, bool> doesItHaveAllTheFeatures = x =>
            {
                FeatureComparer comparer = new FeatureComparer();
                bool b = features.Aggregate(0, (total, y) => x.Features.Contains(y, comparer) == true ? total + 1 : total) == 0;
                return b;
            };

            return products.Where(doesItHaveAllTheFeatures).ToList();
        }
    }

    public class ProductWithFeatures
    {
        public string Name { get; set; }
        public ICollection<Feature> Features { get; set; }
    }

    public class Feature
    {
        public int Id { get; set; }
        
        public Feature(int Id)
        {
            this.Id = Id;
        }
    }

    public class FeatureComparer : IEqualityComparer<Feature>
    {
        public bool Equals(Feature x, Feature y)
        {
            var p = x.Id == y.Id;
            return p;
        }

        public int GetHashCode(Feature obj)
        {
            return obj.Id;
        }
    }
}
