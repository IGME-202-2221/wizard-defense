using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    [SerializeField]
    Text scoreLabel;

    [SerializeField]
    Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = $"Score: {CollisionHandler.score}";
        healthBar.value = Vehicle.healthBarValue;
    }
}
