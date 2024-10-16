using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    [SerializeField] private GameObject cam;
    public GameObject[] target;
    public float health;
    public float targetSpawnRate;
    public float targetTime;
    public int columns;
    public int rows;


    void Awake()
    {
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CameraCenter();
    }

    void Update()
    {
        Debug.Log(health);
        if(health >= 10){
            health = 10;
        }
    }

    void CameraCenter(){
        cam.transform.position = new Vector3(((float)columns / 2) - 0.5f, ((float)rows / 2) - 0.5f, -10);
    }


}
