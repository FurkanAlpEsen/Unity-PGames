using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoldierData", menuName = "Soldier Data")]
public class SoldierData : ScriptableObject
{
    /// <summary>
    /// Scriptable Object datas
    /// </summary>

    #region Received Data

    public int soldierHealth;
    public int attackDamage;
    public float soldierSpeed = 5.0f;
    public string soldierType;

    public Color soldierColor = Color.black;
    
    public Vector3 soldierScale = Vector3.one;

    #endregion

}
