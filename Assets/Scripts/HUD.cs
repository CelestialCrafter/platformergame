using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    [SerializeField] private Text levelText;
    [SerializeField] private Text coinText;

    public int level;
    public int coins;

    void Start() {
	level = 0;
	coins = 0;        
    }

    void Update() {
        levelText.text = "Level " + level;
	coinText.text =  "Coins: " + coins;
    }
}
