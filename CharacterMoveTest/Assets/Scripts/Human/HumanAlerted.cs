using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAlerted : HumanState
{
    bool isStunned;
    bool readyToRun;
    Vector2 direction;
    
    public HumanAlerted(HumanBehavior behavior) : base(behavior)
    {
        curHumanState = humanStateOptions.alerted;
    }
    public override void playerMove()
    {
        Run();
    }
    void Run()
    {
            if (Mathf.Sign(human.transform.position.x - human.player.transform.position.x) == Mathf.Sign(human.moveSpeedX))
            {
                direction = Vector2.right;
                Debug.Log(direction);
            }
            if (Mathf.Sign(human.transform.position.x - human.player.transform.position.x) != Mathf.Sign(human.moveSpeedX))
            {
                    direction = Vector2.left;
            }
            human.transform.Translate(direction * (human.moveSpeedX * 2)* Time.deltaTime);
    }
    
}
