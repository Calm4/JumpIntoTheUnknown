using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _playerAnim;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    void Start()
    {
        PlayerMovement.Instance.OnPlayerMove += StartMoveOnPlayerAnimation;
    }

    private void StartMoveOnPlayerAnimation(bool isMoving)
    {
        _playerAnim.SetBool(IsMoving, isMoving);
        Debug.Log(IsMoving);
    }

    void Update()
    {
        
    }
}
