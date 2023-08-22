using UnityEditor;

[CustomEditor(typeof(PlayerAnimationReaction))]
public class PlayerAnimationReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel ()
    {
        return "Player Animation Reaction";
    }
}
