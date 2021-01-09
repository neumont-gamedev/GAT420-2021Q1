using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAgent : MonoBehaviour
{
    public float speed = 2.0f;
    public float perceptionDistance = 10.0f;
    public float perceptionAngle = 30.0f;
    public bool flee = false;

    void Update()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestGameObject = GetNearestGameObject(gameObjects, out float nearestDistance);

        if (nearestDistance < perceptionDistance)
		{
            Debug.DrawLine(transform.position, nearestGameObject.transform.position);
            Debug.DrawRay(transform.position, transform.forward, Color.red);

            Vector3 direction = (nearestGameObject.transform.position - transform.position).normalized;
            float dot = Vector3.Dot(transform.forward, direction);
            dot = Mathf.Clamp(dot, -1, 1);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

            if (angle <= perceptionAngle)
			{
                direction = (flee) ? -direction : direction;
                Vector3 velocity = direction * speed;
                transform.position += velocity * Time.deltaTime;

                if (direction.magnitude > 0.1f)
                {
                    transform.rotation = Quaternion.LookRotation(direction);
                }
            }
        }

        transform.position = Utilities.Wrap(transform.position, new Vector3(-10, -10, -10), new Vector3(10, 10, 10));
    }

    GameObject GetNearestGameObject(GameObject[] gameObjects, out float nearestDistance)
	{
        nearestDistance = float.MaxValue;

        GameObject nearestGameObject = null;
        foreach(GameObject gameObject in gameObjects)
		{
            if (gameObject == this.gameObject) continue;

            float distance = Vector3.Distance(transform.position, gameObject.transform.position);
            if (distance < nearestDistance)
			{
                nearestDistance = distance;
                nearestGameObject = gameObject;
			}
		}

        return nearestGameObject;
	}


}
