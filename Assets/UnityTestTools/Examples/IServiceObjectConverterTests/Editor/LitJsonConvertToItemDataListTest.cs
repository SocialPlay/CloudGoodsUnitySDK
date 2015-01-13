using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using NUnit.Framework;
using LitJson;

namespace UnityTest
{
    [TestFixture]
    [Category("LitJsonTests")]
    internal class LitJsonConvertToDataListTest
    {
        LitJsonFxJsonObjectConverter litJsonConverter = new LitJsonFxJsonObjectConverter();

        [Test]
        [Category("ConvertToItemDataListTest")]
        public void ConvertToItemDataListTest()
        {
            //List<ItemData> newItemDataList = new List<ItemData>();

            //ItemData testItemDataOne = new ItemData();
            //testItemDataOne.assetURL = "this.jpg";
            //testItemDataOne.baseEnergy = 200;
            //testItemDataOne.behaviours = new List<BehaviourDefinition>();
            //BehaviourDefinition newBehaviourOne = new BehaviourDefinition();
            //newBehaviourOne.Description = "this is this";
            //newBehaviourOne.Energy = 10;
            //newBehaviourOne.ID = 1;
            //newBehaviourOne.Name = "This behaviour";
            //testItemDataOne.behaviours.Add(newBehaviourOne);
            //BehaviourDefinition newBehaviourTwo = new BehaviourDefinition();
            //newBehaviourOne.Description = "this is this";
            //newBehaviourOne.Energy = 10;
            //newBehaviourOne.ID = 1;
            //newBehaviourOne.Name = "This behaviour";
            //testItemDataOne.behaviours.Add(newBehaviourTwo);
            //testItemDataOne.classID = 1;
            //testItemDataOne.CollectionID = 1;
            //testItemDataOne.description = "this is this";
            //testItemDataOne.GenerationID = 0;
            //testItemDataOne.imageName = "this.jpg";
            //testItemDataOne.IsGenerated = false;
            //testItemDataOne.isLocked = false;
            //testItemDataOne.isOwned = true;
            //testItemDataOne.ItemID = 1;
            //testItemDataOne.itemName = "This";
            //testItemDataOne.ownerContainer = null;
            //testItemDataOne.persistantLocation = 1;
            //testItemDataOne.quality = 1;
            //testItemDataOne.salePrice = 10;
            //testItemDataOne.stackSize = 1;
            //testItemDataOne.stats = new Dictionary<string, float>();
            //testItemDataOne.stats.Add("Health", 10);
            //testItemDataOne.stats.Add("Armor", 12);
            //testItemDataOne.tags = new List<string>();
            //testItemDataOne.tags.Add("Pet");
            //testItemDataOne.totalEnergy = 15;
            //testItemDataOne.uiReference = null;

            //newItemDataList.Add(testItemDataOne);

            //string jsonItemData = JsonMapper.ToJson(newItemDataList);

            //List<ItemData> ConvertedListItemData = litJsonConverter.ConvertToItemDataList(jsonItemData);

            //Assert.AreEqual(ConvertedListItemData[0].stackID, testItemDataOne.stackID);
        }
    }
}
