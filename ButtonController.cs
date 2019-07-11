using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool verify;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        verify = true;
    }
    
    public void Easy()
    {
        Health.difficulty = 1;
        verify = true;
    }
    public void Medium()
    {
        Health.difficulty = 2;
        verify = true;
    }
    public void Hard()
    {
        Health.difficulty = 3;
        verify = true;
    }
}
