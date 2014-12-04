using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestNewItemGenerator : MonoBehaviour {

    void Start()
    {
        CloudGoods.OnRegisteredUserToSession += OnUserRegisteredToSession;
    }

    void OnUserRegisteredToSession(string seessionID)
    {
        CloudGoods.NewGenerateItems(10, 300, OnReceviedGenerationResponse);
    }

    void OnReceviedGenerationResponse(GeneratedItems generatedItems)
    {
        Debug.Log("Received generation items count: " + generatedItems.generatedItems.Count + "  GenerationID: " + generatedItems.GenerationID);

        List<SelectedGenerationItem> giveItems = new List<SelectedGenerationItem>();

        foreach(ItemData item in generatedItems.generatedItems)
        {
            Debug.Log("start giving item to user: ID: " + item.ItemID);

            SelectedGenerationItem selectItem = new SelectedGenerationItem();

            selectItem.ItemId = item.ItemID;
            selectItem.Amount = item.stackSize;

            giveItems.Add(selectItem);
        }

        CloudGoods.GiveGeneratedItemToOwner("User", giveItems, generatedItems.GenerationID, 0, OnReceivedGiveItemGenerationResponse);
    }

    void OnReceivedGiveItemGenerationResponse(List<GiveGeneratedItemResult> giveItemResults)
    {

    }


}
