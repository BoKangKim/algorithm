using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Graph;

namespace Algorithm.DFS
{
    public class DFS : MonoBehaviour
    {
        [SerializeField] private Node rootNode;
        private Node curNode = null;
        private Node nextNode = null;

        private void Start()
        {
            StartCoroutine(StartDFS());
        }

        private IEnumerator StartDFS()
        {
            while (true)
            {
                if (curNode != null && curNode.ID == rootNode.ID && rootNode.IsAllVisit())
                {
                    break;
                }

                if (curNode == null)
                {
                    curNode = rootNode;
                    curNode.Visit(null);
                    nextNode = curNode.GetNotVisitedLinkedNode();
                    yield return new WaitForSeconds(0.5f);
                    continue;
                }

                nextNode.Visit(curNode);
                curNode = nextNode;
                nextNode = curNode.GetNotVisitedLinkedNode();
                yield return new WaitForSeconds(0.5f);
            }

            Debug.Log($"[DFS] END");
        }
    }
}