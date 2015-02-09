using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestMoveItemToContainer : MonoBehaviour {

    public GameObject itemContainerPrefab;
    public ItemContainer TargetContainer;

    void OnEnable()
    {
        TargetContainer.AddedItem += TargetContainer_AddedItem;
    }

    void OnDisable()
    {
        TargetContainer.AddedItem -= TargetContainer_AddedItem;
    }

	// Use this for initialization
    void Start()
    {
        ItemData testItemDataOne = CreateTestItemData();

        ItemContainerManager.MoveItem(testItemDataOne, null, TargetContainer);
    }

    void TargetContainer_AddedItem(ItemData arg1, bool arg2)
    {
        if (TargetContainer.containerItems.Exists(x => x.ItemID == 1 && x.stackSize == 1))
            IntegrationTest.Pass(TargetContainer.gameObject);
        else
            IntegrationTest.Fail(TargetContainer.gameObject);
    }

    private static ItemData CreateTestItemData()
    {
        ItemData testItemDataOne = new ItemData();
        testItemDataOne.assetURL = "this.jpg";
        testItemDataOne.baseEnergy = 200;
        testItemDataOne.behaviours = new List<BehaviourDefinition>();
        BehaviourDefinition newBehaviourOne = new BehaviourDefinition();
        newBehaviourOne.Description = "this is this";
        newBehaviourOne.Energy = 10;
        newBehaviourOne.ID = 1;
        newBehaviourOne.Name = "This behaviour";
        testItemDataOne.behaviours.Add(newBehaviourOne);
        BehaviourDefinition newBehaviourTwo = new BehaviourDefinition();
        newBehaviourOne.Description = "this is this";
        newBehaviourOne.Energy = 10;
        newBehaviourOne.ID = 1;
        newBehaviourOne.Name = "This behaviour";
        testItemDataOne.behaviours.Add(newBehaviourTwo);
        testItemDataOne.classID = 1;
        testItemDataOne.CollectionID = 1;
        testItemDataOne.description = "this is this";
        testItemDataOne.GenerationID = 0;
        testItemDataOne.imageName = "this.jpg";
        testItemDataOne.IsGenerated = false;
        testItemDataOne.isLocked = false;
        testItemDataOne.isOwned = true;
        testItemDataOne.ItemID = 1;
        testItemDataOne.itemName = "This";
        testItemDataOne.ownerContainer = null;
        testItemDataOne.persistantLocation = 1;
        testItemDataOne.quality = 1;
        testItemDataOne.salePrice = 10;
        testItemDataOne.stackSize = 1;
        testItemDataOne.stats = new Dictionary<string, string>();
        testItemDataOne.stats.Add("Health", "10");
        testItemDataOne.stats.Add("Armor", "12");
        testItemDataOne.tags = new List<string>();
        testItemDataOne.tags.Add("Pet");
        testItemDataOne.totalEnergy = 15;

        testItemDataOne.uiReference = null;
        return testItemDataOne;
    }
}
