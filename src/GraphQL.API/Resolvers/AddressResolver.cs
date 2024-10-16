namespace GraphQL.API.Resolvers
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Address")]
    public class AddressResolver
    {
        public Task<Address> GetAddressAsync(string id, [Service] IAddressRepository dataRepository) =>
            dataRepository.GetByIdAsync(id);
        public Task<ICollection<Address>> GetAddressListAsync(string[] ids, [Service] IAddressRepository dataRepository)
        {
            if (ids != null && ids.Count() > 0)
            {
                return dataRepository.GetByIdsAsync(ids);
            }
            else
            {
                return null;
            }
        }

        public Task<ICollection<Address>> GetAddressByBuyerAsync([Parent] Buyer buyer, [Service] IAddressRepository dataRepository)
        {
            if (buyer.AddressIds != null && buyer.AddressIds.Count() > 0)
            {
                return dataRepository.GetByIdsAsync(buyer.AddressIds);
            }
            else
            {
                return null;
            }
        }


        public Task<ICollection<Address>> GetAddressBySellerAsync([Parent] Seller seller, [Service] IAddressRepository dataRepository)
        {
            if (seller.AddressIds != null && seller.AddressIds.Count() > 0)
            {
                return dataRepository.GetByIdsAsync(seller.AddressIds);
            }
            else
            {
                return null;
            }
        }

        public Task<ICollection<Address>> GetAddressBySupplierAsync([Parent] Supplier supplier, [Service] IAddressRepository dataRepository)
        {
            if (supplier.AddressIds != null && supplier.AddressIds.Count() > 0)
            {
                return dataRepository.GetByIdsAsync(supplier.AddressIds);
            }
            else
            {
                return null;
            }
        }

    }
}
