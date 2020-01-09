using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuButton : MonoBehaviour
{
    public int numLevel = 1;
    public int numScene = 1;
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = numLevel + " - " + numScene;
    }

    // Update is called once per frame
    public void JumpToScene()
    {
        SceneManager.LoadScene(numScene);
    }
}
