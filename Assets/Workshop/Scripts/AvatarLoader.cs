using UnityEngine;
using ReadyPlayerMe.Core;

public class AvatarLoader : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private RuntimeAnimatorController animatorController;
    [SerializeField] private GameObject disguise;
    [SerializeField] private GameObject ghost;
    
    private void Awake()
    {
        playerMovement.enabled = true;
    }

    private void Start()
    {
        AvatarObjectLoader loader = new AvatarObjectLoader();
        string avatarUrl = PlayerPrefs.GetString("AvatarUrl");
        loader.LoadAvatar(avatarUrl);
        loader.OnCompleted += OnAvatarLoaded;
    }

    private void OnAvatarLoaded(object sender, CompletionEventArgs e)
    {
        ghost.SetActive(false);
        
        GameObject avatar = e.Avatar;
        
        // Set avatar as child of this game object
        avatar.transform.SetParent(transform);
        avatar.transform.localPosition = Vector3.zero;
        avatar.transform.localRotation = Quaternion.identity;
        
        // Set avatar animator
        Animator animator = e.Avatar.GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorController;
        
        playerMovement.animator = animator;
        playerMovement.enabled = true;

        Transform headTop = GameObject.Find("HeadTop_End").transform;
        disguise.transform.SetParent(headTop);
        disguise.transform.localPosition = new Vector3(0, -0.11f, 0.08f);

        ReactionCollection[] reactionColelctions = FindObjectsByType<ReactionCollection>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (ReactionCollection reactionCollection in reactionColelctions)
        {
            reactionCollection.SetPlayerAnimator(animator);
        }
    }
}
