using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItems : MonoBehaviour {


    public Text goldText;
    public Text redText;
    public Text blueText;
    public Player player;
    public int goldCount;
    public int redCount;
    public int blueCount;


    // Use this for initialization
    void Start () {
        goldText = goldText.GetComponent<Text>();
        redText = redText.GetComponent<Text>();
        blueText = blueText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        goldCount = player.goldCount;
        redCount = player.redPotCount;
        blueCount = player.bluePotCount;

        goldText.text = goldCount.ToString();
        redText.text = redCount.ToString();
        blueText.text = blueCount.ToString();
    }
}
