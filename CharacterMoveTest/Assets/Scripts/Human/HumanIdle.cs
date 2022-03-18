using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanIdle : HumanState
{
    public HumanIdle(HumanBehavior humanScript) : base(humanScript)
    {
        curHumanState = humanStateOptions.idle;
    }

    public override void playerMove()
    {
        if(human.transform.position.x >= human.rightBound.x)
        {
            human.direction = Vector2.left;
            
        }
        else if(human.transform.position.x <= human.leftBound.x)
        {
            human.direction = Vector2.right;
        }
        human.transform.Translate(human.direction * (human.moveSpeedX) * Time.deltaTime);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
