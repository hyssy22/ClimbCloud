using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene을 사용하는데 필요하다

public class ClearManager : MonoBehaviour
{
   
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
