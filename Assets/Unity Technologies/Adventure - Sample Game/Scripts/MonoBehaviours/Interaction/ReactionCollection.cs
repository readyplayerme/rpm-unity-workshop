using UnityEngine;

// This script acts as a collection for all the
// individual Reactions that happen as a result
// of an interaction.
public class ReactionCollection : MonoBehaviour
{
    public Reaction[] reactions = new Reaction[0];      // Array of all the Reactions to play when React is called.


    private void Start ()
    {
        // Go through all the Reactions and call their Init function.
        for (int i = 0; i < reactions.Length; i++)
        {
            // The DelayedReaction 'hides' the Reaction's Init function with it's own.
            // This means that we have to try to cast the Reaction to a DelayedReaction and then if it exists call it's Init function.
            // Note that this mainly done to demonstrate hiding and not especially for functionality.
            DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

            if (delayedReaction)
                delayedReaction.Init ();
            else
                reactions[i].Init ();
        }
    }

    public void SetPlayerAnimator(Animator animator)
    {
        foreach (Reaction reaction in reactions)
        {   
            if(reaction is PlayerAnimationReaction)
            {
                PlayerAnimationReaction playerAnimationReaction = reaction as PlayerAnimationReaction;
                playerAnimationReaction.animator = animator;
            }
            
            if(reaction is AnimationReaction)
            {
                AnimationReaction animReaction = reaction as AnimationReaction;
                if(animReaction.isPlayer) animReaction.animator = animator;
            }
        }
    }

    public void React ()
    {
        // Go through all the Reactions and call their React function.
        for (int i = 0; i < reactions.Length; i++)
        {
            // The DelayedReaction hides the Reaction.React function.
            // Note again this is mainly done for demonstration purposes.
            DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

            if(delayedReaction)
                delayedReaction.React (this);
            else
                reactions[i].React (this);
        }
    }
}
