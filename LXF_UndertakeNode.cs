using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LXF_BehaviorTree
{
    /// <summary>
    /// ����LXF_Selectorѡ�����Ǹ���parent_undertakeNodeNodeName���жϵģ����Լ̳���LXF_UndertakeNode���������־ͺ���Ҫ
    /// </summary>
    public class LXF_UndertakeNode : LXF_Node
    {
        public LXF_UndertakeNode(LXF_Selector SelectorChild) : base(SelectorChild)
        {
        }


        public override void OnUpdateNodeBehavior()
        {
            NodeAction();
        }
        public override void NodeAction()
        {
            //Debug.Log($"{this.GetType().Name} is LXF_UndertakeNode excute?");
            //Debug.Log($"SelectorChild is {SelectorChild.GetType().Name}");
            tree.OnExcuteSelector = SelectorChild;
            //Debug.Log($"LXF_Tree.Instance.OnExcuteSelector:{LXF_Tree.Instance.OnExcuteSelector}");
        }

        LXF_Tree tree;
        protected override void Init()
        {
            tree=GetMainEntrance().Tree;
        }

        public override void OnEnterNodeToExecuteOnce()
        {
            
        }

        public override void OnExitNodeToExecuteOnce()
        {
            
        }
    }

}
