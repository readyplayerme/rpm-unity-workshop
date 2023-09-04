using System.Linq;
using UnityEngine;

public class DefaultCharacterControl : MonoBehaviour
{
    private void Awake()
    {
        Component[] components = transform.parent.GetComponents<Component>();

        if(components.All(c => c.GetType().Name != "AvatarLoader"))
        {
            StartScene();
        }
    }

    private void OnDisable()
    {
        if (Application.isPlaying)
        {
            StartScene();
        }
    }
    
    private void StartScene()
    {
        SceneController sceneController = FindObjectOfType<SceneController>();
        if (sceneController != null)
        {
            sceneController.StartCoroutine(sceneController.Fade(0));
        }
    }
}