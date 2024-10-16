using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTile : MonoBehaviour
{
    [SerializeField] private int shotCount = 0;
    [SerializeField] private Animator animator;
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
    void Update()
    {
        if(targetType == TargetType.Empty){
            shotCount = 0;
        }
    }
    void OnMouseDown()
    {
        shotCount--;
        if(targetType == TargetType.Empty){
            animator.SetTrigger("isWrong");
            LevelManager.instance.health--;
        }else if(targetType == TargetType.Normal && shotCount <= 0){
            DeactivateTarget();
            LevelManager.instance.health++;
        }else if(targetType == TargetType.Multi){
            if(targetObj.GetComponent<MultiTarget>().multiNumber == 2){
                DeactivateTarget();
            }else{
                targetObj.GetComponent<MultiTarget>().multiNumber++;
            }
            LevelManager.instance.health++;
        }
        Debug.Log(shotCount);
    }

    public void DeactivateTarget(){
        Destroy(targetObj);
        animator.SetTrigger("isShot");
        targetType = TargetType.Empty;
    }

    public void ActivateTile(GameObject target){
        targetObj = Instantiate(target, transform.position, Quaternion.identity);
        targetObj.transform.SetParent(gameObject.transform);
        
        if(targetType == TargetType.Normal){
            shotCount++;
        }else if(targetType == TargetType.Multi){
            shotCount += targetObj.GetComponent<MultiTarget>().multiNumber + 1;
        }
    }
}
