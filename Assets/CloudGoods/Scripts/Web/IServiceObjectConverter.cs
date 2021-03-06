﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using SocialPlay.Data;

public interface IServiceObjectConverter
{

    List<ItemData> ConvertToItemDataList(string ObjectData);

    Guid ConvertToGuid(string dataString);

    string ConvertToString(string dataString);

    int ConvertToInt(string dataString);

    bool ConvertToBool(string dataString);

    Dictionary<string,string> ConvertToDictionary(string datastring);

    List<StoreItem> ConvertToStoreItems(string dataString);

    CloudGoodsUser ConvertToUserInfo(string dataString);

    List<RecipeInfo> ConvertToListRecipeInfo(string dataString);

    List<ItemBundle> ConvertToListItemBundle(string dataString);

    List<PaidCurrencyBundleItem> ConvertToListPaidCurrencyBundleItem(string dataString);

    MoveMultipleItemsResponse ConvertToMoveMultipleItemsResponse(string dataString);

    UserResponse ConvertToSPLoginResponse(string dataString);

    WorldCurrencyInfo ConvertToWorldCurrencyInfo(string dataString);

    ConsumeResponse ConverToConsumeCreditsResponse(string dataString);

    List<MultipleUserDataValue> ConvertToUserDataValueList(string dataString);

    GeneratedItems ConvertToGeneratedItems(string dataString);

    List<GiveGeneratedItemResult> ConvertToListGiveGenerationItemResult(string dataString);

    PersistentDataResponse ConvertToUserDataResponse(string dataString);

    PurchasePremiumCurrencyBundleResponse ConvertToPurchasePremiumCurrencyBundleResponse(string dataString);

}
