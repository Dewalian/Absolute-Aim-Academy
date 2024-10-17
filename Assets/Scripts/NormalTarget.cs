using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTarget : MonoBehaviour
{
    private TargetTile targetTile;
    private bool startCountdown = true;
    void Start()
    {
        targetTile = GetComponentInParent<TargetTile>();
        targetTile.targetType = TargetTile.TargetType.Normal;
    }

    void Update()
    {
        StartCoroutine(TargetCountdown());
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
