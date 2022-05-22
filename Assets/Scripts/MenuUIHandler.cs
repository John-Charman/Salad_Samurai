using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public Text username;
    public Text highscore;

    void Start()
    {
        highscore.text +="\n" + MainManager.Instance.highscoreName1 + " - " + MainManager.Instance.highscoreValue1;
    }

    public void StartNew()
    {
        if (username.text != "")
        {
            MainManager.Instance.username = username.text;
            SceneManager.LoadScene(1);
        }

    }
}
