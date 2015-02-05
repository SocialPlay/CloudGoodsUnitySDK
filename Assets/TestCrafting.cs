using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestCrafting : MonoBehaviour {

    public ItemRecipeLoader loader;

    void OnEnable()
    {
        CloudGoods.OnUserAuthorized += CloudGoods_OnUserAuthorized;
    }

    void OnDisable()
    {
        CloudGoods.OnUserAuthorized -= CloudGoods_OnUserAuthorized;
    }

    void CloudGoods_OnUserAuthorized(CloudGoodsUser userResponse)
    {
        loader.LoadItemRecipes();
    }

}
