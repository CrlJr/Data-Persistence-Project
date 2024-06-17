using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;

    public string bestScoreName;
    public string inputFieldText;
    public int bestScorePoints;

    public Button startButton;
    public Button quitButton;
    public TMP_InputField inputField;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        bestScoreText.text = "Best Score: " + bestScoreName + ": " + bestScorePoints;
        inputField.text = bestScoreName;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDatas();
    }

    [System.Serializable]
    public class SaveData
    {
        public string bestScoreName;
        public int bestScorePoints;
    }

    public void SaveDatas()
    {
        SaveData data = new SaveData();

        data.bestScoreName = bestScoreName;
        data.bestScorePoints = bestScorePoints;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDatas()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScorePoints = data.bestScorePoints;
            bestScoreName = data.bestScoreName;
        }
    }

    public void StartGame()
    {
        inputFieldText = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }

}
