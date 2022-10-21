using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBrickState : IState
{
    int targetBrick;
    public void OnEnter(BotAI bot)
    {
        targetBrick = Random.Range(3, 5);

        bot.MoveToTarget(bot.ChooseTarget());
    }

    public void OnExcute(BotAI bot)
    {
        if (bot.IsTakingTarget)
        {
            //check du gach voi target brick hay chua
            if (bot.bricksList.Count < targetBrick)
            {
                bot.ChangeState(new BuildBridgeState());
            }
            if(bot.bricksList.Count == 0)
            {
                bot.MoveToTarget(bot.ChooseTarget());
            }
            //+ change state
            //-  bot.SetDestination(bot.ChooseTarget());
        }
    }

    public void OnExit(BotAI bot)
    {
        throw new System.NotImplementedException();
    }

}
