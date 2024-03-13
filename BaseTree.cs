using UnityEngine;

namespace LXF_BehaviorTree
{
    public abstract class BaseTree : MonoBehaviour
    {
        public static BaseTree Instance;

        public LXF_MainEntrance MainEntrance;
        public Node OnExcuteNode;
        public Selector OnExcuteSelector;

        private void Awake()
        {
            Instance = Instance ?? this;
            SetUpTree();
        }

        protected void Start()
        {
            OnExcuteSelector = MainEntrance;
            OnExcuteNode =MainEntrance.defaultNode;
        }


        private void SelectorMonitor()
        {
            OnExcuteSelector.InheritConditionJudgment(this);
            var node = OnExcuteSelector.GetCorrectNodeToOnExcuteNode();
            if (node is null)
            {
                Debug.LogError("无法找到子节点");
            }
            else
            {
                OnExcuteNode = node;
            }
        }
        private void Update()
        {
            if (Time.frameCount % 100 == 0)
            {
                Debug.Log($"Running Selector:{OnExcuteSelector}\n   Running Node:{OnExcuteNode}");
            }
            
            SelectorMonitor();
            OnExcuteNode.OnUpdateNodeBehavior();          
        }


        public abstract void SetUpTree();

    }

}
