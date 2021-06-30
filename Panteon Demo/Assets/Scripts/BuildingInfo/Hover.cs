using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : Singleton<Hover>   
{
    //////  Created Singleton based class show selected buildings on the empty tiles    ///////
    private SpriteRenderer _spriteRenderer;
    private Vector3 _position;
    private void Start()
    {
        this._spriteRenderer = GetComponent<SpriteRenderer>();
        this._position = GetComponent<Transform>().position;
    }
    private void Update()
    {
        FollowMouse();

    }
    private void FollowMouse()      ////  Follow the mouse on screen  ////
    {
        if (_spriteRenderer.enabled)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0); 
        }
    }

    public void Activate(Sprite sprite)  ///   Sprite activated on hover     ///
    {
        this._spriteRenderer.sprite = sprite;
        _spriteRenderer.enabled = true;
    }
    public void Deactivate()    ///   Sprite deactivated on hover selection set null  ///
    {
        _spriteRenderer.enabled = false;
        GameManager.Instance.ClickedBtn = null;
    }
}
