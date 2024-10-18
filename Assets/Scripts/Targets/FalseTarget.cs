using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseTarget : MonoBehaviour
{
    private TargetTile targetTile;
    private bool startCountdown = true;
    void Start()
    {
        targetTile = GetComponentInParent<TargetTile>();
        targetTile.targetType = TargetTile.TargetType.False;
    }

    void Update()
    {
        StartCoroutine(TargetCountdown());
    }

    IEnumerator TargetCountdown(){
        if(startCountdown){
            startCountdown = false;
            yield return new WaitForSeconds(LevelManager.instance.targetTime / 2);
            targetTile.targetType = TargetTile.TargetType.Empty;
            targetTile.animator.SetTrigger("isShot");
            Destroy(gameObject);
        }
    }
}
