using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruta : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] childObjects;
    public List<Transform> childNodeList = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        FillNodes();

        for (int i = 0; i <childNodeList.Count; i++)
        {
            Vector3 currentPos = childNodeList[i].position;
            if (i > 0)
            {
                Vector3 prevPos = childNodeList[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            }
        }
    }
    void FillNodes()
    {
        childNodeList.Clear();
        childObjects = GetComponentsInChildren<Transform>();

        foreach (Transform child in childObjects)
        {
            if (child != this.transform)
            {
                childNodeList.Add(child);
            }
        }


    }


}
