using UnityEngine;
using UnityEngine.AI;

public class MoveState : IStateUnit
{
    private Animator _animator;

    private const string PATH = "Move";

    private readonly string _Vertical;
    private readonly string _Horizontal;

    private readonly NavMeshAgent _agent;


    public MoveState(Animator animator, string horizontal, string vertical, NavMeshAgent navMeshAgent)
    {
        this._animator = animator;
        _Horizontal = horizontal;
        _Vertical = vertical;
        this._agent = navMeshAgent;
    }

    public void Enter()
    {
        _animator.SetBool(PATH, true);
    }

    public void Update()
    {
        Vector3 velocity = _agent.velocity.normalized;

        _animator.SetFloat(_Vertical, velocity.z);
        _animator.SetFloat(_Horizontal, velocity.x);
    }

    public void Exit()
    {
        _animator.SetBool(PATH, false);
        _agent.ResetPath();
    }


}
