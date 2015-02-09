using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UnityUIItemRecipe : MonoBehaviour, IItemRecipe {

    public Text recipeName;
    public RawImage recipeItemImage;

    public Text recipeCraftTime;

    public GameObject IngredientsGrid;
    public GameObject IngredientPrefab;

    public RecipeDetailsWindow recipeDetailsWindow;

    int craftingFactor = 5;

    RecipeInfo recipeInfo;

    public void LoadItemRecipe(RecipeInfo newRecipeInfo)
    {
        recipeInfo = newRecipeInfo;

        recipeName.text = recipeInfo.name;

        recipeCraftTime.text = GetStringCraftTime(newRecipeInfo.energy);

        CloudGoods.GetItemTexture(recipeInfo.imgURL, OnReceivedRecipeImage);

        LoadIngredients(recipeInfo.IngredientDetails);
    }

    void LoadIngredients(List<IngredientDetail> itemIngredients)
    {
        foreach (IngredientDetail ingredient in itemIngredients)
        {
            GameObject ingredientObj = (GameObject)GameObject.Instantiate(IngredientPrefab);
            ingredientObj.transform.SetParent(IngredientsGrid.transform);

            RecipeIngredient recipeIngredient = ingredientObj.GetComponent<RecipeIngredient>();
            recipeIngredient.LoadIngredient(ingredient);
        }
    }

    void OnReceivedRecipeImage(ImageStatus imgStatus, Texture2D img)
    {
        recipeItemImage.texture = img;
    }

    public void OnRecipeButtonClicked()
    {
        recipeDetailsWindow.OpenRecipeDetailsWindow(recipeInfo);
    }

    string GetStringCraftTime(int itemEnergy)
    {
        int craftTime = itemEnergy * craftingFactor;

        TimeSpan craftTimeSpan =TimeSpan.FromSeconds(craftTime);
        
        return "Craft Time: " + craftTimeSpan.ToString();
    }
}
