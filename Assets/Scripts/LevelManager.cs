using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    [SerializeField] private GameObject grid;
    [HideInInspector] public float countDown = 4f;
    [HideInInspector] public bool countDownStart = true;
    [HideInInspector] public bool levelStart = false;
    [HideInInspector] public float time = 60;
    [HideInInspector] public bool win = false;
    [HideInInspector] public bool lose = false;
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
        GameManager.instance.camState = GameManager.CamState.Mid;
        GridCenter();
    }

    void Update()
    {
        StartCoroutine(CountDown());

        if(levelStart){
            time -= Time.deltaTime;
        }

        if(health >= 10){
            health = 10;
        }else if(health <= 0){
            health = 0;
            Lose();
        }

        if(time <= 0){
            Win();
        }
    }

    void GridCenter(){
        grid.transform.position = new Vector3(((float)columns / 2) - 0.5f, ((float)rows / 2) - 0.5f, 0);
    }

    IEnumerator CountDown(){
        if(countDownStart){
            countDownStart = false;
            yield return new WaitForSeconds(countDown);
            levelStart = true;
        }
    }

    public void Win(){
        // Time.timeScale = 0;
        win = true;
        GameManager.instance.camState = GameManager.CamState.Top;
    }

    public void Lose(){
        // Time.timeScale = 0;
        lose = true;
        GameManager.instance.camState = GameManager.CamState.Bot;
    }
}
