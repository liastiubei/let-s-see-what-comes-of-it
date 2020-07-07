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

    public class FeatureCollectionComparer : IEqualityComparer<ICollection<Feature>>
    {
        public bool Equals(ICollection<Feature> x, ICollection<Feature> y)
        {
            return x == y;
        }

        public int GetHashCode(ICollection<Feature> obj)
        {
            int hc = obj.Count;
            foreach (var x in obj)
            {
                hc = unchecked(hc * 314159 + x.Id);
            }
            return hc;
        }
    }
}
