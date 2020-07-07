using LinqHomework;
using System;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace LinqHomeworkTests
{
    public class ProductClassHomeworkTests
    {
        [Fact]
        public void CheckIfReturnProductsWithAtLeastOneFeatureFromTheListWorksCorrectly()
        {
            LinqHomework.Feature[] ids = new LinqHomework.Feature[6];
            ids[0] = new LinqHomework.Feature(1);
            ids[1] = new LinqHomework.Feature(3);
            ids[2] = new LinqHomework.Feature(5);
            ids[3] = new LinqHomework.Feature(7);
            ids[4] = new LinqHomework.Feature(9);
            ids[5] = new LinqHomework.Feature(11);

            List<LinqHomework.ProductWithFeatures> list = new List<LinqHomework.ProductWithFeatures>();
            LinqHomework.Feature[] featuresA = new LinqHomework.Feature[3];
            featuresA[0] = new LinqHomework.Feature(0);
            featuresA[1] = new LinqHomework.Feature(5);
            featuresA[2] = new LinqHomework.Feature(2);
            LinqHomework.ProductWithFeatures productA = new LinqHomework.ProductWithFeatures();
            productA.Name = "a";
            productA.Features = featuresA;
            list.Add(productA);

            LinqHomework.Feature[] featuresB = new LinqHomework.Feature[3];
            featuresB[0] = new LinqHomework.Feature(1);
            featuresB[1] = new LinqHomework.Feature(3);
            featuresB[2] = new LinqHomework.Feature(7);
            LinqHomework.ProductWithFeatures productB = new LinqHomework.ProductWithFeatures();
            productB.Name = "b";
            productB.Features = featuresB;
            list.Add(productB);

            LinqHomework.Feature[] featuresC = new LinqHomework.Feature[3];
            featuresC[0] = new LinqHomework.Feature(10);
            featuresC[1] = new LinqHomework.Feature(4);
            featuresC[2] = new LinqHomework.Feature(8);
            LinqHomework.ProductWithFeatures productC = new LinqHomework.ProductWithFeatures();
            productC.Name = "c";
            productC.Features = featuresC;
            list.Add(productC); 

            LinqHomework.ProductClassHomework productList = new LinqHomework.ProductClassHomework(list);

            List<LinqHomework.ProductWithFeatures> final = new List<LinqHomework.ProductWithFeatures>();

            LinqHomework.Feature[] features1 = new LinqHomework.Feature[3];
            features1[0] = new LinqHomework.Feature(0);
            features1[1] = new LinqHomework.Feature(5);
            features1[2] = new LinqHomework.Feature(2);
            LinqHomework.ProductWithFeatures product1 = new LinqHomework.ProductWithFeatures();
            product1.Name = "a";
            product1.Features = features1;
            final.Add(product1);

            LinqHomework.Feature[] features2 = new LinqHomework.Feature[3];
            features2[0] = new LinqHomework.Feature(1);
            features2[1] = new LinqHomework.Feature(3);
            features2[2] = new LinqHomework.Feature(7);
            LinqHomework.ProductWithFeatures product2 = new LinqHomework.ProductWithFeatures();
            product2.Name = "b";
            product2.Features = features2;
            final.Add(product2);

            var x = new ProductComparer();
            var y = productList.ProductsWithAtLeastOneFeatureFromTheList(ids).ToArray();
            var z = final.ToArray();

            bool a = false, b = false;
            if(y[1].Name == z[1].Name && y[0].Name == z[0].Name)
            {
                a = true;
            }

            var featureComparer = new LinqHomework.FeatureComparer();
            List<bool> boolList = new List<bool>();
            foreach(var p in y[0].Features)
            {
                bool zahar = z[0].Features.Contains(p, featureComparer);
                boolList.Add(zahar);
            }

            foreach (var p in y[1].Features)
            {
                bool zahar = z[1].Features.Contains(p, featureComparer);
                boolList.Add(zahar);
            }

            Assert.True(a && boolList.All(j => j == true));
        }

        public class ProductComparer : IEqualityComparer<LinqHomework.ProductWithFeatures>
        {
            public bool Equals(ProductWithFeatures x, ProductWithFeatures y)
            {
                return x.Features.SequenceEqual(y.Features);
            }

            public int GetHashCode(ProductWithFeatures obj)
            {
                string toHash = obj.Name;
                foreach (var feature in obj.Features)
                    toHash += feature.GetHashCode();

                return toHash.GetHashCode();
            }
        }
    }
}
