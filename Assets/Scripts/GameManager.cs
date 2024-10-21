using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private Texture2D cursor;
    [SerializeField] private GameObject gunshot;
    [SerializeField] private GameObject cam;
    private Vector2 cursorHotspot;
    public int currentStage;

    [Serializable]
    public class LevelStruct{
        public bool isCleared;
        public int score;
        public LevelStruct(bool isCleared, int score){
            this.isCleared = isCleared;
            this.score = score;
        }
    }
    public List<LevelStruct> levels = new();
    public LevelStruct level;
    public float transitionTime;
    public SaveData data;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        if(!File.Exists(Application.persistentDataPath + "/save" +".save")){
            Debug.Log("x");
            currentStage = 0;
            for(int i=0; i<20; i++){
                levels.Add(new LevelStruct(false, 0));
            }

            Save();
        }else{
            Load();
        }
    }

    void Start()
    {
        cursorHotspot = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);
    }

    void Update()
    {
        Gunshot();
        SetCurrentStage();
        SetCurrentLevel();
    }

    void Gunshot(){
        if(Input.GetMouseButtonDown(0) && Time.timeScale != 0){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(gunshot, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
        }
    }

    void SetCurrentStage(){
        if(SceneManager.GetActiveScene().buildIndex > 20){
            currentStage = SceneManager.GetActiveScene().buildIndex;
        }
    }

    void SetCurrentLevel(){
        if(SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex <= 20){
            level = levels[SceneManager.GetActiveScene().buildIndex - 1];
        }
    }

    public void Save(){
        data.currentStage = currentStage;
        data.levels = levels;

        File.WriteAllText(Application.persistentDataPath + "/save" +".save", JsonUtility.ToJson(data, true));
    }

    public void Load(){
        data = JsonUtility.FromJson<SaveData>(File.ReadAllText(Application.persistentDataPath + "/save" +".save"));

        currentStage = data.currentStage;
        levels = data.levels;
    }

    [Serializable]
    public struct SaveData{
        public int currentStage;
        public List<LevelStruct> levels;
    }
}
