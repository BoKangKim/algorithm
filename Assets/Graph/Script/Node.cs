using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Graph
{
    public class Node : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private List<Node> linkedNodeList;
        [SerializeField] private int id;
        public int ID => id;

        [SerializeField] private Node prevNode = null;
        public Node PrevNode => prevNode;

        private bool isVisited = false;
        public bool IsVisited => isVisited;

        public void Visit(Node prevNode = null)
        {
            if (isVisited)
            {
                return;
            }

            this.prevNode = this.prevNode != null ? this.prevNode : prevNode;
            isVisited = true;
            spriteRenderer.color = Color.yellow;
            Debug.Log($"[NODE] Visit [{id}]");
        }

        public Node GetNotVisitedLinkedNode()
        {
            Node target = linkedNodeList.Find((node) => !node.IsVisited);

            if (target == null)
            {
                spriteRenderer.color = Color.green;
                return prevNode;
            }

            return target;
        }

        public bool IsAllVisit()
        {
            int notVisitedCount = 0;

            foreach (var node in linkedNodeList)
            {
                if (!node.IsVisited)
                {
                    notVisitedCount++;
                }
            }

            return notVisitedCount == 0;
        }
    }
}