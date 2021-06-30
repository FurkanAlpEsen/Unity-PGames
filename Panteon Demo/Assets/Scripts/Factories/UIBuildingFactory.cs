using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuildingFactory : GenericFactory<UIBuildingFactory>
{
    /// <summary>
    /// UI ın solundaki butonların oluşması için factory tasarımı kullanıldı. 
    /// </summary>
    public GameObject Instance(GameObject obj){
        return Instantiate(obj);
    }
}
