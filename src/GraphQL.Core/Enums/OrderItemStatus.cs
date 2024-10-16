namespace GraphQL.Core.Enums
{
    public enum OrderItemStatus
    {
        OrderPlaced = 1,
        SellerAcknoledge,
        SellerDelivered,
        WaitingForCustomClearence,
        WarhouseReceived,
        Shipped,
        Delivered
    }
}
