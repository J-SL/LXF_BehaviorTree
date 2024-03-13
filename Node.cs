using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LXF_BehaviorTree
{
    public abstract class Node : BaseNode
    {
        public Node() { }
        public Node(Selector SelectorChild): base(SelectorChild) { }


        public virtual void OnUpdateNodeBehavior()
        {
            NodeAction();
        }

        public abstract void NodeAction();
    }
}

