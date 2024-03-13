using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

namespace LXF_BehaviorTree {
    public abstract class Selector_Universal : BaseNode
    {
        public Node defaultNode { get; protected set; }

        /// <summary>
        /// 每次切换Selector前调用
        /// </summary>
        public void OnSetInit()
        {
            OnGetCorrectNodeToOnExcuteNode=false;
        }

        public bool OnGetCorrectNodeToOnExcuteNode;
        public Selector_Universal(List<Node> nodeChildren) : base(nodeChildren)
        {
            foreach (Node child in nodeChildren)
            {
                var Index = 0;
                NodeChildrenContainer.Add(child.GetType().Name, Index);
                Index++;
            }
        }

        private Dictionary<string, int> NodeChildrenContainer = new Dictionary<string, int>();


        public abstract Node GetCorrectNodeToOnExcuteNode();


        

        protected Node GetNodeFromNodeChildren(string nodeName)
        {
            NodeChildrenContainer.TryGetValue(nodeName, out int value);
            return nodeChildren[value];
        }
    }

}

