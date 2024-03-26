using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LXF_BehaviorTree
{
    public abstract class LXF_Node : BaseNode
    {

        public LXF_Node() { }
        public LXF_Node(LXF_Selector SelectorChild):base(SelectorChild) { }
        public virtual void OnUpdateNodeBehavior()
        {
            NodeAction();
        }

        public abstract void NodeAction();

        public abstract void OnEnterNodeToExecuteOnce();
        public abstract void OnExitNodeToExecuteOnce();
        
        protected LXF_Selector GetAimSelector_UP(string selectorName)
        {
            if(SelectorParent.NodeParent is null) return null;
            if(selectorName != SelectorParent.GetType().Name)
            {
                SelectorParent.NodeParent.GetAimSelector_UP(selectorName);
            }
            return SelectorParent ?? throw new System.Exception("can't get aim selector!");
        }
        protected LXF_Selector GetAimSelector_DOWN(string selectorName)
        {
            if(SelectorChild is null)
            {
                return null;
            }

            if (selectorName != SelectorChild.GetType().Name)
            {
                if (SelectorChild.nodeChildLeft.GetAimSelector_DOWN(selectorName) is null)
                    SelectorChild.nodeChildRight.GetAimSelector_DOWN(selectorName);

            }
            return SelectorChild ?? throw new System.Exception("can't get aim selector!");
        }

        protected LXF_Selector GetAimSelector(string selectorName)
        {
            var s = GetAimSelector_UP(selectorName);
            if (s is null)
                GetAimSelector_DOWN(selectorName);
            return s ?? throw new System.Exception("can't get aim selector!");
        }

        protected LXF_MainEntrance GetMainEntrance()
        {
            if (SelectorParent is LXF_MainEntrance)
            {
                return (LXF_MainEntrance)SelectorParent;
            }

            return SelectorParent.NodeParent.GetMainEntrance() ?? throw new System.Exception("MainEntrance can't get!");
        }


    }
}

