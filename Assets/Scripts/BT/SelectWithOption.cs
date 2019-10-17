using UnityEngine;

namespace AI
{
    public abstract class SelectWithOption : Selector
    {
        [SerializeField]
        private Group successTree;

        [SerializeField]
        private Group failTree;

        public override void Execute()
        {
            if (Check())
            {
                successTree.Execute();
            }
            else
            {
                failTree.Execute();
            }
        }
    }
}