using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishScenes : MonoBehaviour
{
    private void Awake()
    {
         SceneManager.GetActiveScene();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("FinishScenes");

        }
    }
}
