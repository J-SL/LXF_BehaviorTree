using UnityEngine;

namespace LXF_BehaviorTree {
    public abstract class Selector : BaseNode
    {
        public Node defaultNode { get; protected set; }

        private string parent_undertakeNodeNodeName;
        private Selector parent_selector;
        private enum SelectorPoistion { Left, Right };
        private SelectorPoistion GetSelectorPoistion()=>
            parent_selector.nodeChildLeft.GetType().Name==parent_undertakeNodeNodeName? SelectorPoistion.Left:SelectorPoistion.Right;
        private bool _tureOrFalse;

        public Selector(Node nodeChild1, Node nodeChild2) : base(nodeChild1, nodeChild2)
        {
            defaultNode = nodeChild1;

            if (nodeChild1 is UndertakeNode)
            {
                Debug.LogWarning($"{nodeChild1.GetType().Name} had set");
                nodeChild1.SelectorChild.parent_selector = this;
                nodeChild1.SelectorChild.parent_undertakeNodeNodeName= nodeChild1.GetType().Name;
                nodeChild1.SelectorChild._tureOrFalse= nodeChild1.SelectorChild.GetSelectorPoistion() == SelectorPoistion.Left ? true : false;
            }
            else
            {
                Debug.LogWarning($"{nodeChild1.GetType().Name} had not set");
            }

            if(nodeChild2 is UndertakeNode) {
                Debug.LogWarning($"{nodeChild2.GetType().Name} had set");
                nodeChild2.SelectorChild.parent_selector = this;
                nodeChild2.SelectorChild.parent_undertakeNodeNodeName = nodeChild2.GetType().Name;
                nodeChild2.SelectorChild._tureOrFalse = nodeChild1.SelectorChild.GetSelectorPoistion() == SelectorPoistion.Left ? true : false;
            }
            else
            {
                Debug.LogWarning($"{nodeChild2.GetType().Name} had not set");
            }
        }


        public Node GetCorrectNodeToOnExcuteNode() => Condition() ? nodeChildLeft : nodeChildRight;


        /// <summary>
        /// 根据重写的条件判断返回的子Node，条件成立返回nodeChildLeft，否则返回nodeChildRight
        /// </summary>
        /// <returns></returns>
        protected abstract bool Condition();


        public virtual void InheritConditionJudgment(BaseTree tree)
        {
            if (parent_selector.Condition() == _tureOrFalse) parent_selector.InheritConditionJudgment(tree);
            else SetUpOneLevelSelector(tree);
        }
        public void SetUpOneLevelSelector(BaseTree tree)
        {
            tree.OnExcuteSelector = parent_selector;
        }

    }

}

