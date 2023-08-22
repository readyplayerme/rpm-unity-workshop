using UnityEngine;
using ReadyPlayerMe.Core;

public class AvatarLoader : MonoBehaviour
{
    [SerializeField] private string avatarUrl;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private RuntimeAnimatorController animatorController;
    [SerializeField] private GameObject disguise;
    
    private void Start()
    {
        AvatarObjectLoader loader = new AvatarObjectLoader();
        loader.LoadAvatar(avatarUrl);
        loader.OnCompleted += OnAvatarLoaded;
    }

    private void OnAvatarLoaded(object sender, CompletionEventArgs e)
    {
        GameObject avatar = e.Avatar;
        
        avatar.transform.SetParent(transform);
        avatar.transform.localPosition = Vector3.zero;
        avatar.transform.localRotation = Quaternion.identity;
        
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
