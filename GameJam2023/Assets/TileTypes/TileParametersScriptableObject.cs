using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "ScriptableObjects/TileParameters", order = 1)]
public class TileParametersScriptableObject : ScriptableObject
{
    public bool canPlaceTower;
    public Sprite tileSprite;
}
