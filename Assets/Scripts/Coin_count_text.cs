using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_count_text : MonoBehaviour
{
public Text Coins;
    void Update()
    {
       Coins.text =  "Coins: " + PlayerMovee.count + "/5" ;    
    }
}
