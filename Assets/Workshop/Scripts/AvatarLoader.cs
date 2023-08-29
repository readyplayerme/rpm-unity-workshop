using UnityEngine;
using ReadyPlayerMe.Core;

public class AvatarLoader : MonoBehaviour
{
    [SerializeField] private GameObject defaultCharacter;
    [SerializeField] private RuntimeAnimatorController animatorController;
    [SerializeField] private PlayerMovement playerMovement;
    
    private void Start()
    {
        string avatarUrl = PlayerPrefs.GetString("AvatarUrl");
        
        AvatarObjectLoader loader = new AvatarObjectLoader();
        loader.LoadAvatar(avatarUrl);
        loader.OnCompleted += OnAvatarLoaded;
    }

    private void OnAvatarLoaded(object sender, CompletionEventArgs e)
    {
        // Disable default character
        defaultCharacter.SetActive(false);
        
        // Set avatar as child of this game object
        GameObject avatar = e.Avatar;
        avatar.transform.SetParent(transform);
        avatar.transform.localPosition = Vector3.zero;
        avatar.transform.localRotation = Quaternion.identity;
        
        // Set avatar animator
        Animator animator = avatar.GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorController;
        playerMovement.animator = animator;
    }
}
