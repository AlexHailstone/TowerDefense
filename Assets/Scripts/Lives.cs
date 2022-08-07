using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{

    public TextMeshProUGUI livestext;
  
    // Update is called once per frame
    void Update()
    {
        livestext.text = PlayerStats.playerLives.ToString() + "Lives Left";
    }
}
