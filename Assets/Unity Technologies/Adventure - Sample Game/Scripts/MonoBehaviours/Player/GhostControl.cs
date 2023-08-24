using UnityEngine;

public class GhostControl : MonoBehaviour
{
    private void OnDisable()
    {
        // Start scene
        SceneController sceneController = FindObjectOfType<SceneController>();
        MonoBehaviour mb = transform.parent.GetComponent<MonoBehaviour>();
        mb.StartCoroutine(sceneController.Fade(0));
    }
}
