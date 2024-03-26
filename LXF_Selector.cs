using System.Collections.Generic;
using UnityEngine;

namespace LXF_BehaviorTree {
    public abstract class LXF_Selector : BaseNode
    {
        public LXF_Node defaultNode { get; protected set; }

        private string parent_undertakeNodeNodeName;
        private LXF_Selector parent_selector;
        private enum SelectorPoistion { Left, Right };
        private SelectorPoistion GetSelectorPoistion()=>
            parent_selector.nodeChildLeft.GetType().Name==parent_undertakeNodeNodeName? SelectorPoistion.Left:SelectorPoistion.Right;
        private bool _tureOrFalse;

        public LXF_Selector(LXF_Node nodeChildLeft, LXF_Node nodeChildRight) : base(nodeChildLeft, nodeChildRight)
        {
            defaultNode = nodeChildLeft;

            if (nodeChildLeft is LXF_UndertakeNode)
            {
                nodeChildLeft.SelectorChild.parent_selector = this;
                nodeChildLeft.SelectorChild.parent_undertakeNodeNodeName= nodeChildLeft.GetType().Name;
                nodeChildLeft.SelectorChild._tureOrFalse= nodeChildLeft.SelectorChild.GetSelectorPoistion() == SelectorPoistion.Left ? true : false;
            }

            if(nodeChildRight is LXF_UndertakeNode) {

                nodeChildRight.SelectorChild.parent_selector = this;
                nodeChildRight.SelectorChild.parent_undertakeNodeNodeName = nodeChildRight.GetType().Name;
                nodeChildRight.SelectorChild._tureOrFalse = nodeChildRight.SelectorChild.GetSelectorPoistion() == SelectorPoistion.Left ? true : false;
            }
         
        }

        public LXF_Selector(List<LXF_Node> nodeChildren) : base(nodeChildren)
        { }

        //public LXF_Selector() { }

        public virtual LXF_Node GetCorrectNodeToOnExcuteNode() => Condition() ? nodeChildLeft : nodeChildRight;


        /// <summary>
        /// 根据重写的条件判断返回的子Node，条件成立返回nodeChildLeft，否则返回nodeChildRight
        /// </summary>
        /// <returns></returns>
        protected abstract bool Condition();


        public virtual void InheritConditionJudgment(LXF_Tree tree)
        {
            if (parent_selector.Condition() == _tureOrFalse) parent_selector.InheritConditionJudgment(tree);
            else SetUpOneLevelSelector(tree);
        }
        public void SetUpOneLevelSelector(LXF_Tree tree)
        {
            //Debug.LogWarning("this Selector: "+this.GetType().Name+" had SetUpOneLevelSelector!");
            tree.OnExcuteSelector.OnExitSelectorToExecuteOnce();
            tree.OnExcuteSelector = parent_selector;
            parent_selector.OnEnterSelectorToExecuteOnce();

        }

        public virtual void OnEnterSelectorToExecuteOnce() { }
        public virtual void OnExitSelectorToExecuteOnce() { }
    }

}

