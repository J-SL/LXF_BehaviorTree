using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LXF_BehaviorTree
{
    public abstract class LXF_MainEntrance : Selector
    {
        public LXF_MainEntrance(Node nodeChild1, Node nodeChild2) : base(nodeChild1,nodeChild2)
        {
        }

        public override void InheritConditionJudgment(BaseTree tree)
        {
            return;
        }
    }

}

