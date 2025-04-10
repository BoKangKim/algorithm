using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Graph;

namespace Algorithm.BFS
{
    public class BFS : MonoBehaviour
    {
        [SerializeField] private Node rootNode;
        private Queue<Node> visitNodeQueue = new Queue<Node>();
        private WaitForSeconds wait = null;

        private void Start()
        {
            wait = new WaitForSeconds(0.5f);
            StartCoroutine(StartBFS());
        }

        private IEnumerator StartBFS()
        {
            visitNodeQueue.Enqueue(rootNode);
            rootNode.Visit();

            while (visitNodeQueue.Count > 0)
            {
                Node targetNode = visitNodeQueue.Dequeue();

                while (true)
                {
                    Node visitingNode = targetNode.GetNotVisitedLinkedNode();

                    if (visitingNode == null)
                    {
                        yield return wait;
                        break;
                    }

                    if (!visitingNode.IsVisited)
                    {
                        visitingNode.Visit();
                        visitNodeQueue.Enqueue(visitingNode);
                        yield return wait;
                    }
                }
            }

            Debug.Log("[BFS] END");
        }
    }
}