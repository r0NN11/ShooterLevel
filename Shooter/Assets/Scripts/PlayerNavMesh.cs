using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class PlayerNavMesh : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _wayPoints;
    private int _nextWayPointindex = 0;
    private HasEnemies _hasEnemiesScript;
    [SerializeField] private GameOver _gameOver;
    public UnityEvent OnRunEvent { get; private set; } = new UnityEvent();
    public UnityEvent OnIdleEvent { get; private set; } = new UnityEvent();
    public bool start { get; private set; }
    private void Start()
    {
        start = false;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _hasEnemiesScript = _wayPoints[_nextWayPointindex].GetComponent<HasEnemies>();
        OnIdleEvent.Invoke();
    }
    private void Update()
    {
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.5f && start)
        {
            OnIdleEvent.Invoke();
            CheckToMove();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            start = true;
        }
    }
    private void GoToNextWayPoint()
    {
        if (_wayPoints.Length == 0)
        {
            return;
        }
        _nextWayPointindex++;
        _hasEnemiesScript = _wayPoints[_nextWayPointindex].GetComponent<HasEnemies>();
        _navMeshAgent.destination = _wayPoints[_nextWayPointindex].position;
    }
    private void CheckToMove()
    {
        if (_nextWayPointindex == _wayPoints.Length - 1)
        {
            _gameOver.Finish();
            return;
        }
        if (_hasEnemiesScript.hasEnemies())
        {
            GoToNextWayPoint();
            OnRunEvent.Invoke();
        }
    }
    private void OnDestroy()
    {
        OnIdleEvent.RemoveAllListeners();
        OnRunEvent.RemoveAllListeners();
    }

}
