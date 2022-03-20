using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HumanState 
{
    protected readonly HumanBehavior human;
    public enum humanStateOptions { idle, alerted };
    public humanStateOptions curHumanState;
    public HumanState(HumanBehavior behaviorScript)
    {
        human = behaviorScript;
    }

    public virtual void playerMove()
    {

    }
}
