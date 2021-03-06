﻿// ----------------------------------------------------------------------
// <copyright file="KongregatePurchase.cs" company="SocialPlay">
//     Copyright statement. All right reserved
// </copyright>
// Owner: Alex Zanfir
// ------------------------------------------------------------------------
using System;

using UnityEngine;


public class KongregatePurchase : MonoBehaviour, IPlatformPurchaser
{
    public event Action<PurchasePremiumCurrencyBundleResponse> RecievedPurchaseResponse;
    public event Action<PurchasePremiumCurrencyBundleResponse> OnPurchaseErrorEvent;

    void Start()
    {
        Application.ExternalEval("function KongregateOnPurchaseResult(result) {" +   
            "kongregateUnitySupport.getUnityObject().SendMessage('" + name + "', 'OnReceivedPurchaseResponse', result.success.toString());" +
            "}"
            );
    }

    public void Purchase(PremiumBundle bundleItem, int amount, string appID)
    {
        string data = "'{\"id\":\"" + bundleItem.BundleID + "\",\"amount\":\"" + amount + "\",\"type\":\"Premium\",\"appID\":\"" + CloudGoods.AppID + "\"}'";
                string final = "kongregate.mtx.purchaseItemsRemote(" +
           data +
           ", KongregateOnPurchaseResult);";
        Application.ExternalEval(final);
     
    }

    public void OnReceivedPurchaseResponse(PurchasePremiumCurrencyBundleResponse data)
    {    
        if (RecievedPurchaseResponse != null)
            RecievedPurchaseResponse(data);
    }



}

