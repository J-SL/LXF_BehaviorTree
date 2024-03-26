using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

namespace LXF_BehaviorTree {
    public abstract class LXF_Selector_Universal : LXF_Selector
    {

        public LXF_Selector_Universal(List<LXF_Node> nodeChildren) : base(nodeChildren)
        {
            foreach (LXF_Node child in nodeChildren)
            {
                var Index = 0;
                NodeChildrenContainer.Add(child.GetType().Name, Index);
                Index++;
            }
            defaultNode = nodeChildren[0];
        }

        protected Dictionary<string, int> NodeChildrenContainer = new Dictionary<string, int>();

        

        
        protected LXF_Node GetNodeFromNodeChildren(string nodeName)
        {
            NodeChildrenContainer.TryGetValue(nodeName, out int value);
            return nodeChildren[value];
        }
    }

}

