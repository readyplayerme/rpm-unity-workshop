using System.Linq;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    private void Awake()
    {
        Component[] components = transform.parent.GetComponents<Component>();

        if(components.All(c => c.name != "AvatarLoader"))
        {
            StartScene();
        }
    }

    private void OnDisable()
    {
        StartScene();
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
