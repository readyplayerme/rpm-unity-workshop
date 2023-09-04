using UnityEngine;
using ReadyPlayerMe.Core;

public class AvatarLoader : MonoBehaviour
{
    [SerializeField] private GameObject defaultCharacter;

    private void Start()
    {
        string url = PlayerPrefs.GetString("AvatarUrl");

        AvatarObjectLoader loader = new AvatarObjectLoader();
        loader.LoadAvatar(url);
        loader.OnCompleted += OnAvatarLoaded;
    }

    private void OnAvatarLoaded(object sender, CompletionEventArgs args)
    {
        // Disable default character
        defaultCharacter.SetActive(false);

        // Set avatar as child of this game object
        args.Avatar.transform.SetParent(transform, false);
    }
}
