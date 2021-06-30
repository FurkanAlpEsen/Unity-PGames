using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfo : Singleton<BuildingInfo>  //// Created singleton based class /////
{
    [SerializeField] private Image buildingImage;
    [SerializeField] private Text buildingText;
    [SerializeField] private GameObject product;

    public void GetClickedButton(BuildingBtn buildingBtn)     ///   Show the properties of the clicked structure in the info panel  /////     
    {
        buildingImage.sprite = buildingBtn.Sprite;
        buildingText.text = buildingBtn.Text.text;

        if (buildingText.text == "BARRACK")
        {
            product.SetActive(true);
        }
        else if (buildingText.text == "POWER PLANT")
        {
            product.SetActive(false);
        }
    }
    public void ResetInfo()                 ///// Resets the info panel when the selections are reset  /////
    {
        buildingImage.sprite = null;
        buildingText.text = "BUILDING";
        product.SetActive(false);
    }
}
