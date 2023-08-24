using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Button startButton;
    [SerializeField] private Button rpmButton;
    
    private void Start()
    {
        inputField.text = PlayerPrefs.GetString("AvatarUrl");
        startButton.onClick.AddListener(StartGame);
        rpmButton.onClick.AddListener(GoToReadyPlayerMe);
    }

    private void StartGame()
    {
        PlayerPrefs.SetString("AvatarUrl", inputField.text);
        SceneManager.LoadScene("Persistent", LoadSceneMode.Single);
    }
    
    private void GoToReadyPlayerMe()
    {
        Application.OpenURL("https://readyplayer.me/avatar");
    }
}
