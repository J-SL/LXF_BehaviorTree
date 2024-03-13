using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LXF_BehaviorTree
{
    /// <summary>
    /// ����Լ̳������������ֻ��Ҫ��һ�����ΪNode
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
