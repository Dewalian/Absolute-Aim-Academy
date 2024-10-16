using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject targetTile;
    private int columns;
    private int rows;
    private float spawnCD;
    private bool canSpawn = true;
    public List<List<GameObject>> targetTiles = new();

    void Start()
    {
        columns = LevelManager.instance.columns;
        rows = LevelManager.instance.rows;
        BoardSetup();

        // spawnCD = 1 / LevelManager.instance.targetSpawnRate;
        spawnCD = 1;
    }

    void Update()
    {
        StartCoroutine(SpawnTarget());
        
    }

    void BoardSetup(){
        for(int x=0; x<columns; x++){
            targetTiles.Add(new List<GameObject>());
            for(int y=0; y<rows; y++){
                GameObject tileObj = Instantiate(targetTile, new Vector2(x, y), Quaternion.identity);

                targetTiles[x].Add(tileObj);
                tileObj.transform.SetParent(gameObject.transform);
            }
        }
    }

    IEnumerator SpawnTarget(){
        if(canSpawn){
            canSpawn = false;
            GameObject spawnTargetTile;
            TargetTile spawnTargetTileScript = new();

            for(int i=0; i<rows*columns; i++){
                spawnTargetTile = targetTiles[Random.Range(0, columns)][Random.Range(0, rows)];
                spawnTargetTileScript = spawnTargetTile.GetComponent<TargetTile>();
                if(spawnTargetTileScript.targetType == TargetTile.TargetType.Empty){
                    break;
                }
            }
            
            spawnTargetTileScript.ActivateTile(LevelManager.instance.target[Random.Range(0, LevelManager.instance.target.Length)]);

            yield return new WaitForSeconds(spawnCD);
            canSpawn = true;
        }
    }
}

