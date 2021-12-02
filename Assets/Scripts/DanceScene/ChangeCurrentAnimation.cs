using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCurrentAnimation : MonoBehaviour
{
    
    private static readonly int SelectedAnimation = Animator.StringToHash("SelectedAnimation");
    [SerializeField] private Animator animator;

    

    public void Initialize(Animator animator)
    {
        this.animator = animator;
        GameEvents.Current.OnSelectedAnimationChange += ChangeSelectedAnimation;
    }

    public void ChangeSelectedAnimation(Enums.SelectedAnimation selectedAnimation) {
        switch (selectedAnimation)
        {
            case Enums.SelectedAnimation.Animation0:
                CustomValues.SelectedAnimation = 0;
                animator.SetInteger(SelectedAnimation,0);
                //Debug.Log("selected animation 0");
                break;
            case Enums.SelectedAnimation.Animation1:
                CustomValues.SelectedAnimation = 1;
                animator.SetInteger(SelectedAnimation,1);
                //Debug.Log("selected animation 1");
                break;
            case Enums.SelectedAnimation.Animation2:
                CustomValues.SelectedAnimation = 2;
                animator.SetInteger(SelectedAnimation,2);
                //Debug.Log("selected animation 2");
                break;
            case Enums.SelectedAnimation.Animation3:
                CustomValues.SelectedAnimation = 3;
                animator.SetInteger(SelectedAnimation,3);
                //Debug.Log("selected animation 3");
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(selectedAnimation), selectedAnimation, null);
        }
    }
}
