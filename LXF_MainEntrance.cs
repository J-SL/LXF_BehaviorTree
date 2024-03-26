using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LXF_BehaviorTree
{
    public abstract class LXF_MainEntrance : LXF_Selector 
    {
        public LXF_Tree Tree;
        public LXF_MainEntrance(LXF_Node nodeChildLeft, LXF_Node nodeChildRight, LXF_Tree tree) : base(nodeChildLeft, nodeChildRight)
        {
            Tree = tree;
            gameObject = tree.gameObject;
            nodeChildLeft.gameObject= gameObject;
            nodeChildRight.gameObject= gameObject;
        }

        public override void InheritConditionJudgment(LXF_Tree tree)
        {
            return;
        }

        public TNode TryGetAnyNode<TNode>(string nodeName) where TNode : BaseNode
        {
            var tobeFoundList=BaseNodeChildren;
            while (true)
            {
                if (BaseNodeChildren is null) break;
                for (int i=0; i<tobeFoundList.Count; i++)
                {
                    if (tobeFoundList[i].GetType().Name == nodeName) return (TNode)tobeFoundList[i];
                    else
                    {
                        for(int k=0;k< tobeFoundList[i].BaseNodeChildren.Count;k++)
                            tobeFoundList.Add(tobeFoundList[i].BaseNodeChildren[k]);
                        tobeFoundList.Remove(tobeFoundList[i]);
                    }
                }
            }

            throw new System.Exception("can't find target BaseNode,should check node name or tree settings.");           
        }
    }

}

