using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text countDownText;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private RectTransform blackPanelTop;
    [SerializeField] private RectTransform blackPanelBot;
    [SerializeField] private TMP_Text scoreText;
    private Vector2 cBlackPanelEnd = new Vector2(0, 1);
    private float countDown;

    void Start()
    {
        countDown = LevelManager.instance.countDown;
    }

    void Update()
    {
        CountDownUI();
        TimerUI();
        HealthUI();
        ScoreUI();
        MoveBlackPanelIn();

        if(Input.GetKeyDown(KeyCode.Escape)){
            PauseUI();
        }

        if(LevelManager.instance.win){
            winPanel.SetActive(true);
        }

        if(LevelManager.instance.lose){
            losePanel.SetActive(true);
        }
    }

    void CountDownUI(){
        countDown -= Time.deltaTime;
        if(countDown > 3){
            countDownText.text = "3";
        }else if(countDown > 2){
            countDownText.text = "2";
        }else if(countDown > 1){
            countDownText.text = "1";
        }else if(countDown > 0){
            countDownText.text = "GO!";
        }else{
            countDownText.gameObject.SetActive(false);
        }
    }

    void TimerUI(){
        if(LevelManager.instance.time > 0 ){
            int minutes = Mathf.FloorToInt(LevelManager.instance.time / 60);
            int seconds = Mathf.FloorToInt(LevelManager.instance.time % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void HealthUI(){
        healthText.text = string.Format("Health : {0}", LevelManager.instance.health);
        if(LevelManager.instance.health <= 3){
            healthText.color = Color.red;
        }else if(LevelManager.instance.health > 3 && LevelManager.instance.health < 7){
            healthText.color = Color.white;
        }else if(LevelManager.instance.health >= 7){
            healthText.color = Color.green;
        }
    }

    void ScoreUI(){
        scoreText.text = string.Format("Score : {0}", LevelManager.instance.score);
    }

    void PauseUI(){
        if(pausePanel.activeSelf == true){
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }else{
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    void MoveBlackPanelIn(){
        blackPanelTop.anchoredPosition = Vector2.MoveTowards(blackPanelTop.anchoredPosition, cBlackPanelEnd, Time.deltaTime * 6);
        blackPanelBot.anchoredPosition = Vector2.MoveTowards(blackPanelBot.anchoredPosition, cBlackPanelEnd * -1,  Time.deltaTime * 6);
    }

    public void Resume(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit(){
        GameManager.instance.Save();
        SceneManager.LoadScene(GameManager.instance.currentStage);
    }
    public void NextLevel(){
        GameManager.instance.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
