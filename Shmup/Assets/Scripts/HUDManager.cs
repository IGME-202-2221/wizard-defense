using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static bool gameOver = false;

    [SerializeField]
    Text scoreLabel;

    [SerializeField]
    Slider healthBar;

    [SerializeField]
    Slider integrityBar;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    Text healthBonus;
    [SerializeField]
    Text integBonus;
    [SerializeField]
    Text accBonus;

    [SerializeField]
    Text finalScore;

    float healthBon;
    float integrityBon;
    float accBon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = $"Score: {CollisionHandler.score}";
        healthBar.value = Vehicle.health;
        integrityBar.value = EnemyManager.castleIntegrity;
        healthBon = Vehicle.health * 500;
        integrityBon = EnemyManager.castleIntegrity * 50;
        accBon = Mathf.RoundToInt(CollisionHandler.shotsHit / Vehicle.shotsFired * 1000);
        if(healthBon < 0)
        {
            healthBon = 0;
        }
        if (integrityBon < 0)
        {
            integrityBon = 0;
        }
        if (accBon < 0)
        {
            accBon = 0;
        }


        if (Vehicle.health <= 0 || EnemyManager.castleIntegrity <= 0){
            gameOver = true;
            gameOverPanel.SetActive(true);

            healthBonus.text = $"Health Bonus +{healthBon}";
            integBonus.text = $"Integrity Bonus +{integrityBon}";
            accBonus.text = $"Accuracy Bonus +{accBon}";
            if(healthBon <= 0)
            {
                healthBonus.text = $"Health Bonus +0 (you died.)";
            }
            if (integrityBon <= 0)
            {
                integBonus.text = $"Integrity Bonus +0 (your castle was destroyed.)";
            }
            if (accBon <= 0)
            {
                accBonus.text = $"Accuracy Bonus +0 (you either missed every shot or didn't shoot at all.)";
            }
            finalScore.text = $"Final Score: {Mathf.RoundToInt(CollisionHandler.score + accBon + healthBon + integrityBon)}";

        }
        else
        {
            gameOverPanel.SetActive(false);
        }
    }
}
