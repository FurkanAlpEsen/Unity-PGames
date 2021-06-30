using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuildingSpawner : MonoBehaviour
{
    /// <summary>
    /// Scrollun kaydırmalı olması için factory kalıbı uygulanarak spawn işlemi yapılmaktadır
    /// fakat sahneye yerleştirme gerçekleştirilemediği için arka panel de deactive olarak durmaktadır. 
    /// </summary>

    [SerializeField]
    private UIBuildingFactory uiBuildingFactory;

    [SerializeField]
    private GameObject barrackBtnPrefab;
    
    [SerializeField]
    private GameObject powerPlantBtnPrefab;

    private void Start() {
        for(int i = 0; i<= 50;i++)
            Spawn();
    }
    public void Spawn()
    {
        uiBuildingFactory.Instance(barrackBtnPrefab).transform.SetParent(GameObject.Find("Content").transform);

        uiBuildingFactory.Instance(powerPlantBtnPrefab).transform.SetParent(GameObject.Find("Content").transform);

    }
}
