using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageCanvas : MonoBehaviour
{
    [SerializeField] private GameObject[] levelButtons;
    [SerializeField] private GameObject[] scoreTiles;
    [SerializeField] private GameObject nextStageButton;
    [SerializeField] private GameObject prevStageButton;
    [SerializeField] private int firstLevel;
    [SerializeField] private int lastLevel;

    void Start()
    {
        if(firstLevel == 1){
            prevStageButton.SetActive(false);
        }

        if(GameManager.instance.levels[lastLevel - 1].isCleared && firstLevel != 16){
            nextStageButton.SetActive(true);
        }
    }

    void Update()
    {
        ShowLevelButton();
    }

    void ShowLevelButton(){
        for(int i=0; i<5; i++){
            if(GameManager.instance.levels[firstLevel + i - 1].isCleared){
                scoreTiles[i].SetActive(true);
                if(i != 4){
                    levelButtons[i+1].SetActive(true);
                    scoreTiles[i+1].SetActive(true);
                }
            }
        }
    }
}
