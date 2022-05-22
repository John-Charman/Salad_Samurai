using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string username;
    public string highscoreName1;
    public int highscoreValue1;
    
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();

    }
    [System.Serializable]
    class SaveData
    {
        public string highscoreName1;
        public int highscoreValue1;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highscoreName1 = username;
        data.highscoreValue1 = highscoreValue1;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(
            Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscoreName1 = data.highscoreName1;
            highscoreValue1 = data.highscoreValue1;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
