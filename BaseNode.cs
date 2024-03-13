#nullable enable
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace LXF_BehaviorTree
{
    public class BaseNode
    {
        protected List<Node> nodeChildren = new List<Node>();
        public Selector_Universal? Selector_UniversalParent;
       

        protected Node? nodeChildLeft, nodeChildRight;
        

        protected Node? NodeParent;
        public Selector? SelectorChild;
        public Selector? SelectorParent;

        public BaseNode() { }
        public BaseNode(Node nodeChildLeft, Node nodeChildRight)
        {
            this.nodeChildLeft = nodeChildLeft;
            this.nodeChildRight = nodeChildRight;
            nodeChildLeft.SelectorParent= (Selector)this;
            nodeChildRight.SelectorParent = (Selector)this;
        }

        public BaseNode (List<Node> nodeChildren)
        {
            foreach (Node child in nodeChildren)
            {
                this.nodeChildren.Add(child);
                child.Selector_UniversalParent = (Selector_Universal)this;
            }
        }

        public BaseNode(Selector SelectorChild)
        {
            this.SelectorChild = SelectorChild;
            SelectorChild.NodeParent = (Node)this;        
        }        
    }
}

