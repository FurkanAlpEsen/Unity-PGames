using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    /// <summary>
    /// Grid systemini oluşturmak için dışarıdan alınan tilePrefabi kullanılmıştır.
    /// Aynı zamanda kamera harketlerinin yapılabilmesi için de main camera kullanılmıştır.
    /// İlk anda çalışması beklenen bu scriptte Coroutine ler kullanılmıştır.
    /// </summary>

    [SerializeField] 
    private GameObject tilePrefabs;

    [SerializeField]
    private CameraMovement cameraMovement;

    [SerializeField]
    private Transform _map;
    public Dictionary<Point,TileScript> Tiles { get; set; }

    private IEnumerator _coroutine;

    [SerializeField] private int mapX = 20;
    [SerializeField] private int mapY = 11;
    public float TileSize
    {
        get { return tilePrefabs.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    void Start()  /// Start Level Coroutine
    {
        StartCoroutine(nameof(CreateLevel));
    }

    private IEnumerator CreateLevel()  /// Create tile system and place tiles with coroutine
    {
        Tiles = new Dictionary<Point, TileScript>();

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height));

        Vector3 maxTile = Vector3.zero;

        for (int y = 0; y < mapY; y++)
        {
            for (int x = 0; x < mapX; x++)
            {
                _coroutine = PlaceTile(x,y,worldStart);
                StartCoroutine(_coroutine);
            }
        }

        maxTile = Tiles[new Point(mapX - 1, mapY - 1)].transform.position;

        cameraMovement.SetLimits(new Vector3(maxTile.x + TileSize, maxTile.y - TileSize));

        yield return null;
    }
    private IEnumerator PlaceTile(int x, int y, Vector3 worldStart)  /// Place tiles corourtine
    {
        TileScript newTile = Instantiate(tilePrefabs).GetComponent<TileScript>();

        newTile.coroutine = newTile.Setup(new Point(x, y), new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0), _map);

        StartCoroutine(newTile.coroutine);

        yield return null;

    }
}
