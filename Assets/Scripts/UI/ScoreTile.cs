using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTile : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private TMP_Text scoreText;

    void Start()
    {
        scoreText.text = GameManager.instance.levels[level-1].score.ToString();
    }
}
