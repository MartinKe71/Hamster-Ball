using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Scene Reload");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
