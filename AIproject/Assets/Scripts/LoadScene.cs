using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
     void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadGameFunc()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadVictoryFunc()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadDefeatFunc()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
