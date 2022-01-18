using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    private PlayerScript playerScript;
    private Animator anim;

    void Awake()
    {
        playerScript = GetComponent<PlayerScript>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        GameplayController.instance.DisplayHealth(health);
    }
    public void ApplyDamage(int damageAmount)
    {
        health -= damageAmount;
        GameplayController.instance.PlayerHit.Play();
        if (health < 0)
        {
            health = 0;
        }
        //DISPLAY THE HEALTH VALUE
        GameplayController.instance.DisplayHealth(health);

        if (health == 0)
        {
            playerScript.enabled = false;
            anim.Play(MyTags.DEAD_ANIMATION);

            GameplayController.instance.PlayerDie.Play();
            GameplayController.instance.isPlayerAlive = false;
            //CALL THE GAME OVER PANEL
            GameplayController.instance.GameOver();
            // GAMEOVER PANEL
        }
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == MyTags.COIN_TAG)
        {
            target.gameObject.SetActive(false);
            GameplayController.instance.CoinCollected();
            SoundManager.instance.PlayCoinSound();
        }

    }
}
