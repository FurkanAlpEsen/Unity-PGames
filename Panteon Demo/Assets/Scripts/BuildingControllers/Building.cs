using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building: MonoBehaviour, IBuildingSkill
{
    private int _currentHealth;
    [SerializeField] private BuildingData buildingData = null;   //// Get Scriptable object  

    private int _buildingHealth;
    private string _buildingName;

    private void Awake()  /// Caching scriptable objects data
    {
        transform.localScale = buildingData.buildingScale;
        _buildingHealth = buildingData.buildingHealth;
        _buildingName = buildingData.buildingName;
    }
    private void Start() {   
        _currentHealth = _buildingHealth;
    }

    public void TakeDamage(int damage) /// Check the buidilng health
    {  

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            DestroyBuilding();
        }
    }

    public void DestroyBuilding()  /// Destroy buildings (inherited from interface)
    {
        Destroy(gameObject);

        Debug.Log("Building Destroyed!");
    }

}
