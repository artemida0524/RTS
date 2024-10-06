using System;
using System.Net.Security;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public abstract class UnitBase : MonoBehaviour, IUnit, ISelectable
{
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected UnitSelectView _selected;
    [SerializeField] protected Animator _animator;

    public virtual string Vertical { get; protected set; } = "Vertical";
    public virtual string Horizontal { get; protected set; } = "Horizontal";

    protected Camera _camera;
    protected IStateUnit _currentStateUnit;

    public UnitSelectView SelectObject => _selected;

    public Animator Animator => _animator;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        UnitsData.Instance.AddUnits(this);
    }


    private void Update()
    {
        if (_currentStateUnit != null)
        {
            _currentStateUnit.Update();
        }

        ResetMoveState();
    }


    private void OnDestroy()
    {
        UnitsData.Instance.RemoveUnits(this);
    }

    private void ResetMoveState()
    {
        if (_currentStateUnit is MoveState)
        {
            if ((_agent.destination - transform.position).magnitude < 0.05f)
            {
                Debug.Log((_agent.destination - transform.position).magnitude);
                SetState(null);
            }
        }
    }

    public void Select()
    {

        if (_selected == null)
        {
            throw new NullReferenceException($"{_selected} is null");
        }

        _selected.Enable(true);
    }

    public void UnSelect()
    {

        if (_selected == null)
        {
            throw new NullReferenceException($"{nameof(_selected)} is null");
        }

        _selected.Enable(false);
    }

    public Vector2 GetScreenPosition()
    {
        return _camera.WorldToScreenPoint(transform.position);
    }

    public void SetDestination(Vector3 destination)
    {
        if (_agent == null)
        {
            throw new NullReferenceException($"{nameof(_agent)} is null");
        }
        _agent.SetDestination(destination);

        SetState(new MoveState(_animator, Horizontal, Vertical, _agent));
    }
    public virtual void SetState(IStateUnit stateUnit)
    {
        if (_currentStateUnit != null)
        {
            _currentStateUnit.Exit();
        }

        _currentStateUnit = stateUnit;

        if (_currentStateUnit != null)
        {
            _currentStateUnit.Enter();
        }

    }
}
