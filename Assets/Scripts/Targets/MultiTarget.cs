using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTarget : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private TargetTile targetTile;
    private bool startCountdown = true;
    public int multiNumber;
    void Start()
    {
        multiNumber = Random.Range(0, sprites.Length);

        spriteRenderer = GetComponent<SpriteRenderer>();
        targetTile = GetComponentInParent<TargetTile>();
        targetTile.targetType = TargetTile.TargetType.Multi;
    }

    void Update()
    {
        StartCoroutine(TargetCountdown());
        spriteRenderer.sprite = sprites[multiNumber];
    }

    IEnumerator TargetCountdown(){
        if(startCountdown){
            startCountdown = false;
            yield return new WaitForSeconds(LevelManager.instance.targetTime + ((float)multiNumber / 3));
            targetTile.targetType = TargetTile.TargetType.Empty;
            LevelManager.instance.health -= 2;
            targetTile.animator.SetTrigger("isWrong");
            Destroy(gameObject);
        }
    }
}
