using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snake : MonoBehaviour
{
    public ruta currentRoute;
    int routePosition;
    public int steps;
    bool isMoving;
    public Text tirada;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = Random.Range(1,7);
            tirada.text = "Tirada dado= " + steps;
            Debug.Log("Tirando dado.... Resultado> " + steps);

            if (routePosition + steps < currentRoute.childNodeList.Count) {
                StartCoroutine(Move());

            }
            else
            {
                Debug.Log("Tirada invalida muy alto");
            }
        }
    }
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;
        while (steps > 0)
        {
            Vector3 nextPos = currentRoute.childNodeList[routePosition + 1].position;
            while (MoveToNextNode(nextPos)) { yield return null; }
            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;
        }
        isMoving = false;
    }
    bool MoveToNextNode (Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 5f * Time.deltaTime));
        
    }

}
