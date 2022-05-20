using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [Header("Manager")] [SerializeField] private PlayerManager manager;
    [Space]
    [SerializeField] private Animator animator;

    #endregion

    #region Private Variables

    private const string Walk = "Walk";
    private const string Idle = "Idle";


    #endregion

    #endregion

    public void SetAnimationStateToWalk()
    {
        animator.SetTrigger(Walk);
    }

    public void SetAnimationStateToIdle()
    {
        animator.SetTrigger(Idle);
    }

}
