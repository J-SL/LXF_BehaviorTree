using UnityEngine;

namespace LXF_BehaviorTree
{
    public abstract class LXF_Tree : MonoBehaviour
    {
        public LXF_MainEntrance MainEntrance;
        public LXF_Node OnExcuteNode;
        public LXF_Selector OnExcuteSelector;

        private void Awake()
        {
            MainEntrance=SetUpTree();
        }

        protected void Start()
        {
            //if(MainEntrance is null) { Debug.LogError("MainEntrance is null"); }
            MainEntrance.SetUpBaseNode();
            OnExcuteSelector = MainEntrance;
            OnExcuteNode =MainEntrance.defaultNode;
        }


        private void SelectorMonitor()
        {
            if(OnExcuteSelector is null)
            {
                Debug.LogError("OnExcuteSelector is null");
            }
            OnExcuteSelector.InheritConditionJudgment(this);
            var node = OnExcuteSelector.GetCorrectNodeToOnExcuteNode();
            if (node is null)
            {
                Debug.LogError("无法找到子节点");
            }
            else
            {
                //LXF_Debugger.instance.DebuggerInUpdate("node:---------",node.GetType(), 100);
                //LXF_Debugger.instance.DebuggerInUpdate("OnExcuteNode:------------",OnExcuteNode.GetType(), 100);
                if (node.GetType().Name == OnExcuteNode.GetType().Name)
                    return;

                OnExcuteNode.OnExitNodeToExecuteOnce();
                node.OnEnterNodeToExecuteOnce();
                OnExcuteNode = node;
            }
        }
        private void Update()
        {
            if (Time.frameCount % 100 == 0)
            {            
                Debug.Log($"Running Selector:{OnExcuteSelector}\n" +
                    $"      Running Node: {OnExcuteNode}");
            }
           
            SelectorMonitor();
            OnExcuteNode.OnUpdateNodeBehavior();          
        }


        //Link all nodes
        public abstract LXF_MainEntrance SetUpTree();
    }

}
