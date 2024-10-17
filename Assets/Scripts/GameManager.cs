using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float transitionTime = 3f;
    public enum CamState{
        Top,
        Mid,
        Bot
    }
    public CamState camState;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }
}
