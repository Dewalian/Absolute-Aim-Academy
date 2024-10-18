using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTarget : MonoBehaviour
{
    private TargetTile targetTile;
    private bool startCountdown = true;
    private int randomRotation;
    private string test;
    public enum ArrowType{
        Up,
        UpRight,
        Right,
        DownRight,
        Down,
        DownLeft,
        Left,
        UpLeft
    }
    public ArrowType arrowType;

    void Start()
    {
        targetTile = GetComponentInParent<TargetTile>();
        Debug.Log("halo");
        targetTile.targetType = TargetTile.TargetType.Arrow;

        SetRandomRotation();

        targetTile.ArrowTile(arrowType);
    }

    void Update()
    {
        StartCoroutine(TargetCountdown());
    }

    void SetRandomRotation(){
        TargetTile targetTileScript = targetTile.GetComponent<TargetTile>();
        int[] randomInt;

        if(targetTileScript.xPos == 0){

            if(targetTileScript.yPos == 0){
                randomRotation = Random.Range(0, 3);

            }else if(targetTileScript.yPos == LevelManager.instance.rows - 1){
                randomRotation = Random.Range(2, 5);

            }else{
                randomRotation = Random.Range(0, 5);

            }
        }else if(targetTileScript.xPos == LevelManager.instance.columns - 1){

            if(targetTileScript.yPos == 0){
                randomInt = new int[]{0, 6, 7};
                randomRotation = randomInt[Random.Range(0, randomInt.Length)];
                
            }else if(targetTileScript.yPos == LevelManager.instance.rows - 1){
                randomRotation = Random.Range(4, 7);                

            }else{
                randomInt = new int[]{0, 4, 5, 6, 7};
                randomRotation = randomInt[Random.Range(0, randomInt.Length)];

            }
        }else if(targetTileScript.yPos == 0){
            test = "bawah";
            randomInt = new int[]{0, 1, 2, 6, 7};
            randomRotation = randomInt[Random.Range(0, randomInt.Length)];
            
        }else if(targetTileScript.yPos == LevelManager.instance.rows - 1){
            test = "atas";
            randomRotation = Random.Range(2, 7);
        }else{
            randomRotation = Random.Range(0, 8);
        }

        arrowType = (ArrowType)randomRotation;
        transform.rotation = Quaternion.Euler(0, 0, -45 * randomRotation);
    }

    IEnumerator TargetCountdown(){
        if(startCountdown){
            startCountdown = false;
            yield return new WaitForSeconds(LevelManager.instance.targetTime);
            targetTile.targetType = TargetTile.TargetType.Empty;
            LevelManager.instance.health--;
            targetTile.animator.SetTrigger("isWrong");
            Destroy(gameObject);
        }
    }
}
