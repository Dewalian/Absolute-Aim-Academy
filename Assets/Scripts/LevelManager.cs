using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    void Awake()
    {
        if(instance = null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
    }
}
