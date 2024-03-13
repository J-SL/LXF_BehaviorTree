using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LXF_BehaviorTree
{
    /// <summary>
    /// 你可以继承自这个类来做只需要做一遍的行为Node
    /// </summary>
    public class UndertakeNode : Node
    {
        public UndertakeNode(Selector SelectorChild) : base(SelectorChild)
        {
        }


        public override void OnUpdateNodeBehavior()
        {
            NodeAction();
        }
        public override void NodeAction()
        {
            BaseTree.Instance.OnExcuteSelector = SelectorChild;
        }
    }

}
