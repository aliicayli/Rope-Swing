using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManagement : MonoBehaviour
{
    public bool isPlay = false;
 
  


    private void Start()
    {
        Time.timeScale = 0f;
    }

   

    public void PlayGame()
    {
        Time.timeScale = 1f;
        isPlay = true;
    }
    
}
