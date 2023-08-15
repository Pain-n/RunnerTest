using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    public GameController Controller;
    public TextMeshProUGUI ResultsText;
    public Button RestartButton;
    void Start()
    {
        ResultsText.text = $"Score: {Controller.Score} \n Best Score: {GameController.BestScore}";

        RestartButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        });
    }
}
