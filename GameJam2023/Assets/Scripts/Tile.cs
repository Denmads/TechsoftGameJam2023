using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileParametersScriptableObject parameters;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = parameters.tileSprite;
    }
}
