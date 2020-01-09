using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public bool saved;
    public int lives = 3;

    private bool isDead;
    private Vector3 savedPos;

    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas winCanvas;

    private void Awake()
    {
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayManager");
        Cursor.visible = false;
        gameOverCanvas.enabled = false;
        winCanvas.enabled = false;
        OnSavePoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y - savedPos.y < -15 && !isDead) HandleDeath();
    }

    public void OnSavePoint()
    {
        saved = true;
        savedPos = transform.position;
    }

    public void OnWinFlag()
    {
        HandleWin();
    }


    private void HandleWin()
    {
        winCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void HandleDeath()
    {
        isDead = true;
        if (!saved || lives <= 1)
        {
            lives = 0;
            gameOverCanvas.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            transform.position = savedPos;
            lives--;
            GetComponent<MovementController>().ClearForce();
        }
        isDead = false;
    }
}
