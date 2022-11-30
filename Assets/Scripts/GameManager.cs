using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    public GameManager instance;
    bool pauseMenuisActive = false;
    Canvas pauseMenuCanvas;
    private void Awake()
    {
        current = this;
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
        
    }
    private void Start()
    {
        pauseMenuCanvas = GetComponentInChildren<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu(pauseMenuisActive);
            pauseMenuisActive = !pauseMenuisActive;
        }
    }

    public void PauseMenu(bool pauseMenuisActive)
    {
        

        pauseMenuCanvas.enabled = !pauseMenuisActive;
        
    }
}
