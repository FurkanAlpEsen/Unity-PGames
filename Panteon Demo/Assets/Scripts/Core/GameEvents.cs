using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : Singleton<GameEvents>
{
    /// <summary>
    /// Bir askerin başka bir askere veya bir binaya temas etmesi halinde tetiklenmesi için yazılmış bir eventtir.
    /// Asker bir binaya veya başka bir askere saldırabildiği için doğrudan attack metoduna bağlıdır.
    /// </summary>
    public event Action onSoldierTriggerEnter;
    public void SoldierTriggerEnter(){
        
        if(onSoldierTriggerEnter != null){
            onSoldierTriggerEnter();
        }
    }      
}
