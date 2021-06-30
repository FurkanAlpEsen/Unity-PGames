using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// Game Manager created singleton based
    /// we need to access everywhere 
    /// </summary>
    public BuildingBtn ClickedBtn { get; set; }

    private void Update()  /// check the every frame escape key...
    {
        HandleEscape();
    }

    public void PickBuilding(BuildingBtn buildingBtn)  /// Selected building assign..
    {
        this.ClickedBtn = buildingBtn;

        BuildingInfo.Instance.GetClickedButton(buildingBtn);

        Hover.Instance.Activate(buildingBtn.Sprite);
    }
    public void BuyBuilding() /// After the buildings place, reset hover and info... 
    {
        Hover.Instance.Deactivate();
        
        BuildingInfo.Instance.ResetInfo();
    }
    private void HandleEscape() /// escape key cancel the selection..
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.Deactivate();
            BuildingInfo.Instance.ResetInfo();
        }
    }

}
