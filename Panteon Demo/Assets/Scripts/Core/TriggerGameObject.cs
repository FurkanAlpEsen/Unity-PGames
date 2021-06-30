using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameObject : MonoBehaviour
{
    /// <summary>
    /// Colliderların temas ettiği ilk anda çalışır.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other) 
    {
         GameEvents.Instance.SoldierTriggerEnter();
         //Debug.Log("Triggered object: " + other);
    }
}
