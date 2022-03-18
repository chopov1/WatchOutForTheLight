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
    // Start is called before the first frame update
    

    public virtual void playerMove()
    {

    }
}
