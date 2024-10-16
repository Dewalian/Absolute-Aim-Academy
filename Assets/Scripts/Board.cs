using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int columns = 3;
    [SerializeField] private int rows = 3;
    [SerializeField] private GameObject targetTile;
    [SerializeField] private GameObject cam;
    private List<List<TargetTile>> targetTiles = new();

    void Start()
    {
        CameraCenter();
        BoardSetup();
    }

    void CameraCenter(){
        cam.transform.position = new Vector3(((float)columns / 2) - 0.5f, ((float)rows / 2) - 0.5f, -10);
    }

    void BoardSetup(){
        for(int x=0; x<columns; x++){
            targetTiles.Add(new List<TargetTile>());
            for(int y=0; y<rows; y++){
                TargetTile rowTargetTile = new();
                GameObject toInstantiate = Instantiate(targetTile, new Vector2(x, y), Quaternion.identity);

                targetTiles[x].Add(rowTargetTile);
                toInstantiate.transform.SetParent(gameObject.transform);

            }
        }
    }

}

