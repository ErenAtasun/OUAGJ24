using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class LivesControl : MonoBehaviour
{
    private void Update()
    {

        switch (Score.lives)
        {
            case 3:
                break;
            case 2:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                break;
            default:
                Score.lives = 3;
                break;
        }
    }
}
