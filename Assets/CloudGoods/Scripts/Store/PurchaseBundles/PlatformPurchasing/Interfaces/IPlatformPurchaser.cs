﻿// ----------------------------------------------------------------------
// <copyright file="IPlatformPurchaser.cs" company="SocialPlay">
//     Copyright statement. All right reserved
// </copyright>
// Owner: Alex Zanfir
// ------------------------------------------------------------------------
using System;

public interface IPlatformPurchaser
{
    event Action<PurchasePremiumCurrencyBundleResponse> RecievedPurchaseResponse;
    event Action<PurchasePremiumCurrencyBundleResponse> OnPurchaseErrorEvent;

    void Purchase(PremiumBundle id, int amount, string userID);
    void OnReceivedPurchaseResponse(PurchasePremiumCurrencyBundleResponse data);
}

