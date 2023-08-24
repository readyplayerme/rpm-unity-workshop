using UnityEngine;
using ReadyPlayerMe.Core;

public class AvatarLoader : MonoBehaviour
{
    [SerializeField] private GameObject ghost;
    [SerializeField] private RuntimeAnimatorController animatorController;
    
    private PlayerMovement playerMovement;
    
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        
        string avatarUrl = PlayerPrefs.GetString("AvatarUrl");
        
        AvatarObjectLoader loader = new AvatarObjectLoader();
        loader.LoadAvatar(avatarUrl);
        loader.OnCompleted += OnAvatarLoaded;
    }

    private void OnAvatarLoaded(object sender, CompletionEventArgs e)
    {
        // Disable ghost character
        ghost.SetActive(false);
        
        // Set avatar as child of this game object
        GameObject avatar = e.Avatar;
        avatar.transform.SetParent(transform);
        avatar.transform.localPosition = Vector3.zero;
        avatar.transform.localRotation = Quaternion.identity;
        
        // Set avatar animator
        Animator animator = e.Avatar.GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorController;
        playerMovement.animator = animator;
    }
}
