using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BuildingData", menuName ="Building Data")]
public class BuildingData : ScriptableObject
{
    public int buildingHealth;
    public string buildingName;

    public Color buildingColor = Color.black;
    public Vector3 buildingScale = Vector3.one;

}
