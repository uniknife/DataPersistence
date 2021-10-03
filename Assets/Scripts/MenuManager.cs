using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;
    public InputField NameInputFeild;

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance != null && DataManager.Instance.bestPlayerName != null)
        {
            BestScoreText.text = "Best Score : " + DataManager.Instance.bestPlayerName + " : " + DataManager.Instance.bestScore;
            NameInputFeild.text = DataManager.Instance.bestPlayerName;
        }

        NameInputFeild.onEndEdit.AddListener(delegate{DataManager.Instance.UpdatePlayerName(NameInputFeild.text);});
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
