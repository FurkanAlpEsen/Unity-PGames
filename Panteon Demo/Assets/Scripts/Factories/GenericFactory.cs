using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// Normalde askerler object pool paterni ile üretilerek saheneye yerleştiriliyor 
    /// fakat Factory patterni kullanmak için ya yapılar üretilmeli ya da askerler üretilmeli
    /// burada tercih askerler tarafından olmuştur ve havuzda üretilen askerler fabrika içerisine alınarak return edilmiştir.
    /// object olmasaydı direkt olararak Instantiate metoduyla spawn edilebilirdi. 
    /// </summary>
    public GameObject GetNewInstance(){            
        return SoldierSpawner.Instance.Spawn();
    }
}
