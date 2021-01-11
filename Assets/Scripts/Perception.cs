using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Perception : MonoBehaviour
{
    [SerializeField] protected float distance = 10.0f;
    [SerializeField] protected float angle = 30.0f;
    [SerializeField] protected string tagName = "";

    public abstract GameObject GetGameObject();
    public abstract GameObject[] GetGameObjects();

    public GameObject[] GetGameObjectsInDistance(GameObject[] gameObjects, float distanceMax)
    {
        List<GameObject> result = new List<GameObject>();

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject == this.gameObject) continue;

            float distance = Vector3.Distance(transform.position, gameObject.transform.position);
            if (distance < distanceMax)
            {
                result.Add(gameObject);
            }
        }

        return result.ToArray();
    }

    public GameObject[] GetGameObjectsInAngle(GameObject[] gameObjects, float angleMax)
    {
        List<GameObject> result = new List<GameObject>();

        foreach (GameObject gameObject in gameObjects)
        {
			Vector3 direction = (gameObject.transform.position - transform.position).normalized;
			float dot = Vector3.Dot(transform.forward, direction);
			dot = Mathf.Clamp(dot, -1, 1);
			float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
            if (angle < angleMax)
            {
                result.Add(gameObject);
            }
        }

        return result.ToArray();
    }

    public GameObject GetNearestGameObject(GameObject[] gameObjects)
    {
        float nearestDistance = float.MaxValue;

        GameObject nearestGameObject = null;
        foreach (GameObject gameObject in gameObjects)
        {
            float distance = Vector3.Distance(transform.position, gameObject.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestGameObject = gameObject;
            }
        }

        return nearestGameObject;
    }

    public GameObject[] SortGameObjectsByDistance(GameObject[] gameObjects)
	{
        List<GameObject> sortGameObjects = new List<GameObject>(gameObjects); 
        sortGameObjects.Sort(SortByDistance);

        return sortGameObjects.ToArray();
    }

    int SortByDistance(GameObject gameObjectA, GameObject gameObjectB)
    {
        float distanceA = (gameObjectA.transform.position - transform.position).sqrMagnitude;
        float distanceB = (gameObjectB.transform.position - transform.position).sqrMagnitude;

        return distanceA.CompareTo(distanceB);
    }
}
