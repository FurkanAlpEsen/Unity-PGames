using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingBtn : MonoBehaviour
{
    ////////      assign building prefabs, sprites and texts in inspector           //////////////

    [SerializeField]
    private GameObject buildingPrefab;

    public GameObject BuildingPrefab
    {
        get
        {
            return buildingPrefab;
        }
    }

    [SerializeField]
    private Sprite sprite;
    public Sprite Sprite 
    { 
        get
        {
            return sprite;
        } 
    }

    [SerializeField] 
    private Text text;    
    public Text Text
    {
        get
        {
            return text;
        }
    }
}
