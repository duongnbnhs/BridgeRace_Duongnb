using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class BotAI : Character
{
    NavMeshAgent agent;
    [SerializeField]
    public BrickGenerator brickGenerator;
    IState currentState;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        ChangeState(new SeekBrickState());
    }
    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExcute(this);
        }
    }
    public List<GameObject> targetsList;
    public Vector3 ChooseTarget()
    {
        Vector3 target = Vector3.zero;
        foreach (var brick in brickGenerator.spawnedBricks)
        {
            if (brick.colorData.colorName == characcterColorData.colorName && !brick.removed)
            {
                target = brick.position;
                break;
            }
        }
        return target;
    }
    public void ChangeState(IState state)
    {
        if(currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;
        if(currentState != null)
        {
            currentState.OnEnter(this);
        }
            
    }
    Vector3 des;
    internal void MoveToTarget(Vector3 value)
    {
        des = value;
        agent.SetDestination(value);
    }

    public bool IsTakingTarget => Vector3.Distance(this.transform.position, des) < 0.1f;

}
