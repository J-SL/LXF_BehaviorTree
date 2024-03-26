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
        /// ��ǰ�ڵ���ӽڵ�
        /// </summary>
        public List<BaseNode>? BaseNodeChildren = new();
        /// Selector�������Ӽ���ΪNode����
        /// </summary>
        public LXF_Node? nodeChildLeft, nodeChildRight;      
        /// <summary>
        /// Selector�ĸ�����ΪNode����
        /// </summary>
        public LXF_Node? NodeParent;
        /// <summary>
        /// Node���Ӽ���ΪSelector����
        /// </summary>
        public LXF_Selector? SelectorChild;
        // <summary>
        /// Node�ĸ�����ΪSelector����
        /// </summary>
        public LXF_Selector? SelectorParent;

        /// <summary>
        /// Tree������gameObject
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
        /// �˷����ڳ�SetUpTree������һ֡����
        /// </summary>
        protected abstract void Init();

        #region ������
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

