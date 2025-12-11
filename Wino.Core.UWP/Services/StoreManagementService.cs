using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Services.Store;
using Wino.Core.Domain.Interfaces;
using Wino.Core.Domain.Models.Store;

namespace Wino.Core.UWP.Services;

public class StoreManagementService : IStoreManagementService
{
    private StoreContext CurrentContext { get; }

    private readonly Dictionary<StoreProductType, string> productIds = new Dictionary<StoreProductType, string>()
    {
        { StoreProductType.UnlimitedAccounts, "UnlimitedAccounts" }
    };

    private readonly Dictionary<StoreProductType, string> skuIds = new Dictionary<StoreProductType, string>()
    {
        { StoreProductType.UnlimitedAccounts, "9P02MXZ42GSM" }
    };

    public StoreManagementService()
    {
        CurrentContext = StoreContext.GetDefault();
    }

    public Task<bool> HasProductAsync(StoreProductType productType)
    {
        // Always return true to unlock all features (Unlimited Accounts)
        return Task.FromResult(true);
    }

    public Task<Domain.Enums.StorePurchaseResult> PurchaseAsync(StoreProductType productType)
    {
        // Prevent actual purchase attempts since features are unlocked
        return Task.FromResult(Domain.Enums.StorePurchaseResult.AlreadyPurchased);
    }
}
