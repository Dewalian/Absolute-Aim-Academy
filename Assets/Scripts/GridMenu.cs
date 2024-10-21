using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMenu : MonoBehaviour
{
    void Start()
    {
        SetGridPosition(GameManager.instance.currentStage);
    }

    void SetGridPosition(string stage){
        if(stage == "Stage 1"){
            transform.position = new Vector2(0, 0);
        }else if(stage == "Stage 2"){
            transform.position = new Vector2(-18, 0);
        }else if(stage == "Stage 3"){
            transform.position = new Vector2(-36, 0);
        }else if(stage == "Stage 4"){
            transform.position = new Vector2(-54, 0);
        }
    }
}
