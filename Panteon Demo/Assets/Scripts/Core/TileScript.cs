using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get;private set; }
    public bool IsEmpty{ get; set; }

    private Color32 _fullColor = new Color32(255, 0, 0, 255);
    private Color32 _emptyColor = new Color32(96, 255, 90, 255);
    private Color32 _firstColor = new Color32(77, 73, 159, 255);
    private SpriteRenderer _spriteRenderer;
    public IEnumerator coroutine;
    public SoldierFactory soldierFactory;

    private void Awake()  //// caching..
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _firstColor;
    }

    public Vector2 WorldPosition /// Return position
    {
        get
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2),transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y/2));
        }
    }

    public IEnumerator Setup(Point gridPos, Vector3 worldPos,Transform parent)  /// Level setup coroutine..
    {
        IsEmpty = true;
        this.GridPosition = gridPos;
        transform.position = worldPos;

        transform.SetParent(parent);

        LevelManager.Instance.Tiles.Add(gridPos, this);

        yield return null;
    }
    private void OnMouseOver()
    {
 
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBtn != null)
        {
            if (IsEmpty)
            {
                ColorTile(_emptyColor);
            }
            if (!IsEmpty)
            {
                ColorTile(_fullColor);
                IsEmpty = true;
            }
            else if (Input.GetMouseButtonDown(0))
            {                
                PlaceBuilding();
            }
        }
    }
    private void OnMouseExit()
    {
        ColorTile(_firstColor);
    }
    public void PlaceBuilding()  /// Place the buildings..
    {      
        GameObject building = (GameObject)Instantiate(GameManager.Instance.ClickedBtn.BuildingPrefab, transform.position, Quaternion.identity);

        building.transform.SetParent(transform);
     
        IsEmpty = false;

        SoldierPositionInBuilding();

        ColorTile(Color.white);

        GameManager.Instance.BuyBuilding();
    }

    private void ColorTile(Color32 newColor) /// Reset sprite color..
    {
        _spriteRenderer.color = newColor;
    }
    private void SoldierPositionInBuilding() /// soldiers created by object pools but returned Soldier factory and replaced near buildings
    {

        if (GameManager.Instance.ClickedBtn.Text.text == "BARRACK")
        {
            var inst = soldierFactory.GetNewInstance(); 
            inst.transform.position = transform.position - new Vector3(2, 0, 0);
        }

    }

}
