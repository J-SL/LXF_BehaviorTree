#nullable enable
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace LXF_BehaviorTree
{
    public abstract class BaseNode
    {
        public List<LXF_Node> nodeChildren = new List<LXF_Node>();
        public LXF_Selector_Universal? Selector_UniversalParent;

        /// <summary>
        /// 当前节点的子节点
        /// </summary>
        public List<BaseNode>? BaseNodeChildren = new();
        /// Selector的两个子级，为Node类型
        /// </summary>
        public LXF_Node? nodeChildLeft, nodeChildRight;      
        /// <summary>
        /// Selector的父级，为Node类型
        /// </summary>
        public LXF_Node? NodeParent;
        /// <summary>
        /// Node的子级，为Selector类型
        /// </summary>
        public LXF_Selector? SelectorChild;
        // <summary>
        /// Node的父级，为Selector类型
        /// </summary>
        public LXF_Selector? SelectorParent;

        /// <summary>
        /// Tree依附的gameObject
        /// </summary>
        public GameObject? gameObject
        {
            get ; set;  
        }


        public void SetUpBaseNode()
        {
            if (this is LXF_Selector)
            {
                if (nodeChildLeft is null || nodeChildRight is null) throw new System.Exception("Selector children have not correct add!");
                nodeChildLeft.gameObject = gameObject;
                nodeChildRight.gameObject = gameObject;
                nodeChildLeft.SetUpBaseNode();
                nodeChildRight.SetUpBaseNode();
            }else if(this is LXF_UndertakeNode)
            {
                if (SelectorChild is null) throw new System.Exception("Node children have not correct add!");
                SelectorChild.gameObject=gameObject;
                SelectorChild.SetUpBaseNode();
            }else if(this is LXF_Node)
            {
                
            }
            else
            {
                throw new System.Exception("Add a type which not a Selector Or Node!");
            }

            Init();
        }

        /// <summary>
        /// 此方法在初SetUpTree（）后一帧调用
        /// </summary>
        protected abstract void Init();

        #region 构造器
        public BaseNode() { }
        public BaseNode(LXF_Node nodeChildLeft, LXF_Node nodeChildRight)
        {
            this.nodeChildLeft = nodeChildLeft;
            this.nodeChildRight = nodeChildRight;
            nodeChildLeft.SelectorParent= (LXF_Selector)this;
            nodeChildRight.SelectorParent = (LXF_Selector)this;

            BaseNodeChildren.Add(nodeChildLeft);
            BaseNodeChildren.Add(nodeChildRight);
        }

        public BaseNode (List<LXF_Node> nodeChildren)
        {
            foreach (LXF_Node child in nodeChildren)
            {
                this.nodeChildren.Add(child);
                child.Selector_UniversalParent = (LXF_Selector_Universal)this;

                BaseNodeChildren.Add(child);
            }
        }

        public BaseNode(LXF_Selector SelectorChild)
        {
            this.SelectorChild = SelectorChild;
            SelectorChild.NodeParent = (LXF_Node)this;

            BaseNodeChildren.Add(SelectorChild);
        }
        #endregion


    }
}

