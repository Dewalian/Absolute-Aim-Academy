using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject targetTile;
    private int columns;
    private int rows;
    private Vector2 cShiftPos;
    private float shiftSpeed;
    private float rotationSpeed;
    private float spawnCD;
    private bool canSpawn = true;
    private bool boardOnRight = false;
    private Vector2 boardCenter;
    public List<List<GameObject>> targetTiles = new();

    void Start()
    {
        columns = LevelManager.instance.columns;
        rows = LevelManager.instance.rows;

        cShiftPos = LevelManager.instance.cShiftPos;
        shiftSpeed = LevelManager.instance.shiftSpeed;
        rotationSpeed = LevelManager.instance.rotationSpeed;
        
        BoardSetup();

        spawnCD = 1 / LevelManager.instance.targetSpawnRate;

        boardCenter = new Vector2(columns / 2 - 0.5f, rows / 2 - 0.5f);
    }

    void Update()
    {
        if(LevelManager.instance.levelStart){
            StartCoroutine(SpawnTarget());
            if(shiftSpeed > 0){
                ShiftBoard();
            }
            
            if(rotationSpeed != 0){
                RotateBoard();
            }
            
            LevelManager.instance.boardQuat = transform.rotation;
        }
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

    void ShiftBoard(){
        if(Vector2.Distance(transform.position, cShiftPos) <= 0.1f){
            boardOnRight = true;
        }else if(Vector2.Distance(transform.position, cShiftPos * -1) <= 0.1f){
            boardOnRight = false;
        }

        if(!boardOnRight){
            transform.position = Vector2.MoveTowards(transform.position, cShiftPos, shiftSpeed * Time.deltaTime);
        }else if(boardOnRight) {
            transform.position = Vector2.MoveTowards(transform.position, cShiftPos * -1, shiftSpeed * Time.deltaTime);
        }
    }

    void RotateBoard(){
        transform.RotateAround(boardCenter, Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    IEnumerator SpawnTarget(){
        if(canSpawn){
            canSpawn = false;
            GameObject spawnTargetTile = new();
            TargetTile spawnTargetTileScript = spawnTargetTile.AddComponent<TargetTile>();

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

