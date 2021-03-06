﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnityUIBundlePurchasePopupHandler : MonoBehaviour {

    public PremiumCurrencyBundleStore bundleStore;
    public GameObject PurchaseWindow;

    public Text purchaseMessage;

    bool platformPurchaserSet = false;


	// Use this for initialization
	void Update () {
        if (bundleStore.platformPurchasor != null && platformPurchaserSet == false)
        {
			Debug.Log("platform purchase set");
            bundleStore.platformPurchasor.OnPurchaseErrorEvent += platformPurchasor_RecievedPurchaseResponse;
            bundleStore.platformPurchasor.RecievedPurchaseResponse += platformPurchasor_RecievedPurchaseResponse;

            platformPurchaserSet = true;
        }
	}

    void OnDisable()
    {
        bundleStore.platformPurchasor.OnPurchaseErrorEvent -= platformPurchasor_RecievedPurchaseResponse;
        bundleStore.platformPurchasor.RecievedPurchaseResponse -= platformPurchasor_RecievedPurchaseResponse;

    }

    void platformPurchasor_RecievedPurchaseResponse(PurchasePremiumCurrencyBundleResponse obj)
    {
        Debug.Log("Purchase popup event called");

        PurchaseWindow.SetActive(true);

        if (obj.StatusCode == 1)
            purchaseMessage.text = "Purchase Successful";
        else
            purchaseMessage.text = obj.Message;
    }

    public void CloseWindow()
    {
        PurchaseWindow.SetActive(false);
    }
}
