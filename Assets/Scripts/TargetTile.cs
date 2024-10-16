using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTile : MonoBehaviour
{
    [SerializeField] private int shotCount = 0;
    private Board board;
    private GameObject targetObj;
    public enum TargetType{
        Empty,
        Normal,
        Multi
    }
    public TargetType targetType;

    void Start()
    {
        board = GetComponentInParent<Board>();
    }
    void OnMouseDown()
    {
        shotCount--;
        if(targetType == TargetType.Empty){
            LevelManager.instance.health--;
            shotCount = 0;
        }else{
            DeactivateTarget();
            LevelManager.instance.health++;
        }
        Debug.Log("yeah");
    }

    void DeactivateTarget(){
        Destroy(targetObj);
        targetType = TargetType.Empty;
    }

    public void ActivateTile(GameObject target){
        targetObj = Instantiate(target, transform.position, Quaternion.identity);
        targetObj.transform.SetParent(gameObject.transform);
        
        if(targetType == TargetType.Normal){
            shotCount++;
        }
    }
}
