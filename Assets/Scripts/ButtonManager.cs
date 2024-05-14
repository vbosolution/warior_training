using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public OptionsManager optionsManager;
    public void ExitGame()
    {

        Application.Quit();
        #if UNITY_EDITOR
            // If running in Unity Editor
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void StartGame()
    {
        optionsManager.SaveOptions();
        SceneManager.LoadScene("PlayScene");
    }
}
