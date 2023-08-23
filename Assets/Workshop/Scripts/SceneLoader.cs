using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Button button;
    
    private void Start()
    {
        inputField.text = PlayerPrefs.GetString("AvatarUrl");
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        PlayerPrefs.SetString("AvatarUrl", inputField.text);
        SceneManager.LoadScene("Persistent", LoadSceneMode.Single);
    }
}
