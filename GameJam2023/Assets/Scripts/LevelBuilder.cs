using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject tilePrefab;
    public GameObject basePrefab;

    [Header("Tiles")]
    public TileParametersScriptableObject normalTile;
    public TileParametersScriptableObject pathTile;

    [Header("Settings")]
    public int width = 10;
    public int height = 10;
    public Vector2 basePosition;

    [Header("Path")]
    public List<Vector2> path;
    private List<Vector2> allPathPoints = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = height / 2f;
        Camera.main.transform.position = new Vector3(width / 2f, height / 2, -10);

        CalcPathPoints();

        Dictionary<(int, int), GameObject> tiles = new Dictionary<(int, int), GameObject>();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var newTile = Instantiate(tilePrefab, transform);
                newTile.transform.Translate(0.5f + x, 0.5f + y, 0);

                if (isPath(x, y))
                    newTile.GetComponent<Tile>().parameters = pathTile;
                else
                    newTile.GetComponent<Tile>().parameters = normalTile;
                newTile.SetActive(true);

                tiles.Add((x, y), newTile);
            }
        }

        Instantiate(basePrefab, new Vector3(0.5f + basePosition.x, 0.5f + basePosition.y), Quaternion.identity);
    }

    private void CalcPathPoints()
    {
        for (int i = 0; i < path.Count-1; i++)
        {
            var from = path[i];
            var to = path[i+1];

            var x = from.x;
            var y = from.y;
            
            var dir = to - from;
            var dirX = dir.x != 0 ? Mathf.Sign(dir.x) : 0;
            var dirY = dir.y != 0 ? Mathf.Sign(dir.y) : 0;

            while (x != (int)to.x || y != (int)to.y)
            {
                allPathPoints.Add(new Vector2(x, y));
                x += dirX;
                y += dirY;
            }
        }
    }

    private bool isPath(int x, int y)
    {
        return allPathPoints.Contains(new Vector2(x, y));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
