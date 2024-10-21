using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetTile : MonoBehaviour
{
    private Board board;
    private GameObject targetObj;
    public int xPos;
    public int yPos;
    public Animator animator;
    public enum TargetType{
        Empty,
        Normal,
        Multi,
        False,
        Arrow
    }
    public TargetType targetType;
    public List<TargetTile> pointingTiles = new();

    void Start()
    {
        board = GetComponentInParent<Board>();
        xPos = (int)transform.localPosition.x;
        yPos = (int)transform.localPosition.y;
    }
    void OnMouseDown()
    {
        if(Time.timeScale == 0 || !LevelManager.instance.levelStart){
            return;
        }

        if(pointingTiles.Count == 0){
            TargetTileClicked();
        }else{
            PointingTileClicked();
        }
    }

    void AddPointingTile(int xPlus, int yPlus){
        TargetTile pointingTile = board.targetTiles[xPos+xPlus][yPos+yPlus].GetComponent<TargetTile>();
        pointingTile.pointingTiles.Add(this);
    }

    void TargetTileClicked(){
        if(targetType == TargetType.Empty || targetType == TargetType.Arrow){

            animator.SetTrigger("isWrong");
            AudioManager.instance.PlaySFX(2);
            LevelManager.instance.health--;
            CalcScore(-10);
            
        }else if(targetType == TargetType.Normal){

            DeactivateTarget();
            LevelManager.instance.health++;
            CalcScore(20);

        }else if(targetType == TargetType.Multi){

            if(targetObj.GetComponent<MultiTarget>().multiNumber == 0){
                DeactivateTarget();
            }else{
                targetObj.GetComponent<MultiTarget>().multiNumber--;
            }
            LevelManager.instance.health++;
            CalcScore(25);

        }else if(targetType == TargetType.False){

            DeactivateTarget();
            LevelManager.instance.health--;
            CalcScore(-20);
        }
    }

    void PointingTileClicked(){
        pointingTiles[0].GetComponent<TargetTile>().DeactivateTarget();
        pointingTiles.Remove(pointingTiles[0]);
        LevelManager.instance.health++;
        CalcScore(30);
    }

    void CalcScore(int score){
        LevelManager.instance.score += score;
    }

    public void ArrowTile(ArrowTarget.ArrowType arrowType){
        Debug.Log("Terpanggil");
        if(arrowType == ArrowTarget.ArrowType.Up){
            AddPointingTile(0, 1);
        }else if(arrowType == ArrowTarget.ArrowType.UpRight){
            AddPointingTile(1, 1);
        }else if(arrowType == ArrowTarget.ArrowType.Right){
            AddPointingTile(1, 0);
        }else if(arrowType == ArrowTarget.ArrowType.DownRight){
            AddPointingTile(1, -1);
        }else if(arrowType == ArrowTarget.ArrowType.Down){
            AddPointingTile(0, -1);
        }else if(arrowType == ArrowTarget.ArrowType.DownLeft){
            AddPointingTile(-1, -1);
        }else if(arrowType == ArrowTarget.ArrowType.Left){
            AddPointingTile(-1, 0);
        }else if(arrowType == ArrowTarget.ArrowType.UpLeft){
            AddPointingTile(-1, 1);
        }
    }

    public void ActivateTile(GameObject target){
        targetObj = Instantiate(target, transform.position, LevelManager.instance.boardQuat);
        targetObj.transform.SetParent(gameObject.transform);
    }

    public void DeactivateTarget(){
        Destroy(targetObj);
        if(targetType == TargetType.False){
            animator.SetTrigger("isWrong");
            AudioManager.instance.PlaySFX(2);
        }else{
            animator.SetTrigger("isShot");
            AudioManager.instance.PlaySFX(1);
        targetType = TargetType.Empty;
        }
    }
}
