using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TestNewItemGenerator : MonoBehaviour {

    public List<float> newGenerationTimes = new List<float>();
    public List<float> oldGenerationTimes = new List<float>();

    public List<float> newGiveItemTimes = new List<float>();
    public List<float> oldGiveItemTimes = new List<float>();

    float testTime = 5.0f;
    float time = 0.0f;

    bool startTest = false;

    void Start()
    {
        CloudGoods.OnRegisteredUserToSession += OnUserRegisteredToSession;
    }

    void OnUserRegisteredToSession(string seessionID)
    {
        startTest = true;
    }

    void FixedUpdate()
    {
        if (startTest)
        {
            time += Time.deltaTime;

            if (time < testTime)
            {
                TimeNewCallbackTest();
                TimeOldCallbackTest();

                startTest = false;
            }
            else
            {
                startTest = false;
                time = 0.0f;
            }

        }
    }

    private float CalculateAverage(List<float> listOfTimes, ref float totalTime)
    {
        foreach (float newTime in listOfTimes)
        {
            totalTime += newTime;
        }

        float averageTime = totalTime / listOfTimes.Count;
        return averageTime;
    }

    private void TimeNewCallbackTest()
    {
        DateTime startTime = DateTime.Now;

        CloudGoods.NewGenerateItems(10, 300, delegate(GeneratedItems generatedItems)
        {
            Debug.Log("Response for generate NEW: " + DateTime.Now.Millisecond);

            TimeSpan timeSpan = DateTime.Now - startTime;

            float timeDifference = (float)timeSpan.Milliseconds;

            newGenerationTimes.Add(timeDifference);

            OnReceviedNewGenerationResponse(generatedItems);

            if (!startTest)
            {
                float totalNewTime = 0.0f;
                float averageNewTime = CalculateAverage(newGenerationTimes, ref totalNewTime);

                Debug.Log("Average Time of callback GENERATE NEW test is : " + averageNewTime + " ms");
            }
        });

    }


    void OnReceviedNewGenerationResponse(GeneratedItems generatedItems)
    {
        List<SelectedGenerationItem> giveItems = new List<SelectedGenerationItem>();

        SelectedGenerationItem selectItem = new SelectedGenerationItem();

        if (generatedItems.generatedItems.Count > 0)
        {
            selectItem.ItemId = generatedItems.generatedItems[0].ItemID;
            selectItem.Amount = generatedItems.generatedItems[0].stackSize;
        }

        giveItems.Add(selectItem);

        DateTime newGiveItemTime = DateTime.Now;

        Debug.Log("Start of Give item date NEW: " + newGiveItemTime.Millisecond);

        CloudGoods.GiveGeneratedItemToOwner("User", giveItems, generatedItems.GenerationID, 0, delegate(List<GiveGeneratedItemResult> Items)
        {

            Debug.Log("Start of Give item date NEW: " + newGiveItemTime.Millisecond + " end of time : " + DateTime.Now.Millisecond);

            TimeSpan timeSpan = DateTime.Now - newGiveItemTime;

            float timeDifference = (float)timeSpan.Milliseconds;

            newGiveItemTimes.Add(timeDifference);

            if (!startTest)
            {
                float totalNewTime = 0.0f;
                float averageNewTime = CalculateAverage(newGiveItemTimes, ref totalNewTime);

                Debug.Log("Average Time of callback GIVE NEW test is : " + averageNewTime + " ms");
            }
        });
    }


    private void TimeOldCallbackTest()
    {
        DateTime startTime = DateTime.Now;

        CloudGoods.GenerateItemsAtLocation("User", 0, 10, 300, delegate(List<ItemData> generatedItems)
        {
            Debug.Log("Response for generate OLD: " + DateTime.Now.Millisecond);

            TimeSpan timeSpan = DateTime.Now - startTime;

            float timeDifference = (float)timeSpan.Milliseconds;

            oldGenerationTimes.Add(timeDifference);

            OnReceviedOldGenerationResponse(generatedItems);

            if (!startTest)
            {
                float totalOldTime = 0.0f;
                float averageOldTime = CalculateAverage(oldGenerationTimes, ref totalOldTime);

                Debug.Log("Average Time of callback GENERATE OLD test is : " + averageOldTime + " ms");
            }
        });

    }


    void OnReceviedOldGenerationResponse(List<ItemData> generatedItems)
    {
        ItemData itemData = generatedItems[0];

        DateTime oldGiveItemTime = DateTime.Now;
        Debug.Log("Start date time of OLD : " + DateTime.Now.Millisecond);

        CloudGoods.MoveItemStack(itemData.stackID, itemData.stackSize, CloudGoods.user.userID.ToString(), "User", 0, delegate(Guid Items)
        {
            Debug.Log("Start of Give item date OLD: " + oldGiveItemTime.Millisecond + " end of time : " + DateTime.Now.Millisecond);
            TimeSpan timeSpan = DateTime.Now - oldGiveItemTime;

            float timeDifference = (float)timeSpan.Milliseconds;

            oldGiveItemTimes.Add(timeDifference);

            if (!startTest)
            {
                float totalOldTime = 0.0f;
                float averageOldTime = CalculateAverage(oldGiveItemTimes, ref totalOldTime);

                Debug.Log("Average Time of callback GIVE OLD test is : " + averageOldTime + " ms");
            }
        });
    }


}
