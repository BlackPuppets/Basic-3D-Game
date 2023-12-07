using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation {

    //This was made as a study, but it is not currently being used!!!!

    public enum AnimationType
    {
        None,
        Idle,
        Run,
        Attack,
        Death
    }

    public class AnimationBase : MonoBehaviour
    {
        [SerializeField]private Animator animator;
        public List<AnimationSetup> animationSetups;

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            var setup = animationSetups.Find(i => i.animationType == animationType);
            if (setup != null) animator.SetTrigger(setup.trigger);
        }
    }

    [System.Serializable]
    public class AnimationSetup
    {
        public AnimationType animationType;
        public string trigger;
    }

}