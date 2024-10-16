using GraphQL.Core.Entities;
using HotChocolate.Data.Filters;
using HotChocolate.Types;
using System;

namespace GraphQL.API.Filters
{
    public class ProductFilterType : FilterInputType<Product>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Product> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f.Name).Type<CustomStringOperationFilterInputType>();
            descriptor.Field(f => f.Sku).Type<CustomStringOperationFilterInputType>();
            descriptor.Field(f => f.ModelNo).Type<CustomStringOperationFilterInputType>();
            descriptor.Field(f => f.Summary).Type<CustomStringOperationFilterInputType>();
            descriptor.Field(f => f.Description).Type<CustomStringOperationFilterInputType>();
            descriptor.Field(f => f.BasePrice).Type<CustomDoubleOperationFilterInputType>();
            descriptor.Field(f => f.SalePrice).Type<CustomDoubleOperationFilterInputType>();
            descriptor.Field(f => f.CostPrice).Type<CustomDoubleOperationFilterInputType>();
            descriptor.Field(f => f.ActualPrice).Type<CustomDoubleOperationFilterInputType>();
            descriptor.Field(f => f.Quantity).Type<CustomIntOperationFilterInputType>();
            descriptor.Field(f => f.ActualCreatedAt).Type<CustomDateOperationFilterInputType>();
            descriptor.Field(f => f.CreatedAt).Type<CustomDateOperationFilterInputType>();

            descriptor.Field(f => f.IsNew).Type<CustomBooleanOperationFilterInputType>();
            descriptor.Field(f => f.IsFeatured).Type<CustomBooleanOperationFilterInputType>();
            descriptor.Field(f => f.IsOnSale).Type<CustomBooleanOperationFilterInputType>();
            descriptor.Field(f => f.IsSoldOut).Type<CustomBooleanOperationFilterInputType>();
            descriptor.Field(f => f.IsStockEnabled).Type<CustomBooleanOperationFilterInputType>();
            descriptor.Field(f => f.IsVariation).Type<CustomBooleanOperationFilterInputType>();
        }



        public class CustomStringOperationFilterInputType : StringOperationFilterInputType
        {
            protected override void Configure(IFilterInputTypeDescriptor descriptor)
            {
                descriptor.Operation(DefaultFilterOperations.Equals).Type<StringType>();
                descriptor.Operation(DefaultFilterOperations.NotEquals).Type<StringType>();
                descriptor.Operation(DefaultFilterOperations.Contains).Type<StringType>();
                descriptor.Operation(DefaultFilterOperations.NotContains).Type<StringType>();
                descriptor.Operation(DefaultFilterOperations.StartsWith).Type<StringType>();
                descriptor.Operation(DefaultFilterOperations.EndsWith).Type<StringType>();
                //descriptor.Operation(DefaultFilterOperations.And).Type<StringType>();
                //descriptor.Operation(DefaultFilterOperations.Or).Type<StringType>();
            }
        }

        public class CustomIntOperationFilterInputType : ComparableOperationFilterInputType<IntType>
        {
            protected override void Configure(IFilterInputTypeDescriptor descriptor)
            {
                descriptor.Operation(DefaultFilterOperations.Equals).Type<IntType>();
                descriptor.Operation(DefaultFilterOperations.NotEquals).Type<IntType>();
                descriptor.Operation(DefaultFilterOperations.LowerThan).Type<IntType>();
                descriptor.Operation(DefaultFilterOperations.LowerThanOrEquals).Type<IntType>();
                descriptor.Operation(DefaultFilterOperations.NotLowerThan).Type<IntType>();
                descriptor.Operation(DefaultFilterOperations.NotLowerThanOrEquals).Type<IntType>();
                descriptor.Operation(DefaultFilterOperations.GreaterThan).Type<IntType>();
                descriptor.Operation(DefaultFilterOperations.GreaterThanOrEquals).Type<IntType>();
                descriptor.Operation(DefaultFilterOperations.NotGreaterThan).Type<IntType>();
                descriptor.Operation(DefaultFilterOperations.NotGreaterThanOrEquals).Type<IntType>();
            }
        }

        public class CustomDoubleOperationFilterInputType : ComparableOperationFilterInputType<DecimalType>
        {
            protected override void Configure(IFilterInputTypeDescriptor descriptor)
            {
                descriptor.Operation(DefaultFilterOperations.Equals).Type<IntType>();
                descriptor.Operation(DefaultFilterOperations.NotEquals).Type<IntType>();
                descriptor.Operation(DefaultFilterOperations.LowerThan).Type<DecimalType>();
                descriptor.Operation(DefaultFilterOperations.LowerThanOrEquals).Type<DecimalType>();
                descriptor.Operation(DefaultFilterOperations.NotLowerThan).Type<DecimalType>();
                descriptor.Operation(DefaultFilterOperations.NotLowerThanOrEquals).Type<DecimalType>();
                descriptor.Operation(DefaultFilterOperations.GreaterThan).Type<DecimalType>();
                descriptor.Operation(DefaultFilterOperations.GreaterThanOrEquals).Type<DecimalType>();
                descriptor.Operation(DefaultFilterOperations.NotGreaterThan).Type<DecimalType>();
                descriptor.Operation(DefaultFilterOperations.NotGreaterThanOrEquals).Type<DecimalType>();
            }
        }


        public class CustomDateOperationFilterInputType : ComparableOperationFilterInputType<DateTimeType>
        {
            protected override void Configure(IFilterInputTypeDescriptor descriptor)
            {
                descriptor.Operation(DefaultFilterOperations.Equals).Type<DateTimeType>();
                descriptor.Operation(DefaultFilterOperations.NotEquals).Type<DateTimeType>();
                descriptor.Operation(DefaultFilterOperations.LowerThan).Type<DateTimeType>();
                descriptor.Operation(DefaultFilterOperations.LowerThanOrEquals).Type<DateTimeType>();
                descriptor.Operation(DefaultFilterOperations.NotLowerThan).Type<DateTimeType>();
                descriptor.Operation(DefaultFilterOperations.NotLowerThanOrEquals).Type<DateTimeType>();
                descriptor.Operation(DefaultFilterOperations.GreaterThan).Type<DateTimeType>();
                descriptor.Operation(DefaultFilterOperations.GreaterThanOrEquals).Type<DateTimeType>();
                descriptor.Operation(DefaultFilterOperations.NotGreaterThan).Type<DateTimeType>();
                descriptor.Operation(DefaultFilterOperations.NotGreaterThanOrEquals).Type<DateTimeType>();
            }
        }

        public class CustomBooleanOperationFilterInputType : BooleanOperationFilterInputType
        {
            protected override void Configure(IFilterInputTypeDescriptor descriptor)
            {
                descriptor.Operation(DefaultFilterOperations.Equals).Type<BooleanType>();
                descriptor.Operation(DefaultFilterOperations.NotEquals).Type<BooleanType>();
            }
        }

    }
}
