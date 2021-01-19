using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;

    Player player;

    Slider healthBar;

    void Start()
    {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<Player>();

        healthBar = FindObjectOfType<Slider>();
        healthBar.maxValue = player.GetHealth();
    }


    void Update()
    {
        healthText.text = player.GetHealth().ToString();

        healthBar.value = player.GetHealth();
    }
}
