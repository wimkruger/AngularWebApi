﻿using AdventureWorks.Domain;
using System.Linq;
using System;
using AdventureWorks.DataAccess.Utils;

namespace AdventureWorks.DataAccess.Specifications
{
    public class ProductSpecification : ISpecification<Product>
    {
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal? ListPrice { get; set; }
        public DateTime? SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public int? Size { get; set; }
        public decimal? Weight { get; set; }
        public int? DaysToManufacture { get; set; }
        public int? Category { get; set; }
        public string SubCategory { get; set; }

        public IQueryable<Product> IsSatisfiedBy(IQueryable<Product> queryable)
        {
            return queryable
                .NullableWhere(x => x.Name == Name)
                .NullableWhere(x => x.ProductNumber == ProductNumber)
                .NullableWhere(x => x.Color == Color)
                .NullableWhere(x => x.StandardCost == StandardCost)
                .NullableWhere(x => x.SubCategory.Name == SubCategory)
                .NullableWhere(x => (int)x.SubCategory.Category == Category);
        }
    }
}
