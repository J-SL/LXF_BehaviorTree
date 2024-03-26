using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LXF_BehaviorTree
{
    /// <summary>
    /// 由于LXF_Selector选择器是根据parent_undertakeNodeNodeName来判断的，所以继承自LXF_UndertakeNode更换其名字就很重要
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
