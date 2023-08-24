using UnityEngine;

public class AnimationReaction : DelayedReaction
{
    public bool isPlayer;
    public Animator animator;   // The Animator that will have its trigger parameter set.
    public string trigger;      // The name of the trigger parameter to be set.


    private int triggerHash;    // The hash representing the trigger parameter to be set.


    protected override void SpecificInit ()
    {
        triggerHash = Animator.StringToHash(trigger);
    }


    protected override void ImmediateReaction ()
    {
        if (isPlayer)
        {
            var player = GameObject.FindWithTag("Player");
            animator = player.GetComponent<PlayerMovement>().animator;
        }
        
        animator.SetTrigger (triggerHash);
    }
}
