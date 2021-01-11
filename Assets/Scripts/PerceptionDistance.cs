using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionDistance : Perception
{
	public override GameObject GetGameObject()
	{
		GameObject[] gameObjects = (tagName == "") ? GameObject.FindObjectsOfType<GameObject>() : GameObject.FindGameObjectsWithTag(tagName);

		gameObjects = GetGameObjectsInDistance(gameObjects, distance);
		gameObjects = GetGameObjectsInAngle(gameObjects, angle);
		gameObjects = SortGameObjectsByDistance(gameObjects);

		return (gameObjects == null) ? null : gameObjects[0];
	}

	public override GameObject[] GetGameObjects()
	{
		GameObject[] gameObjects = (tagName == "") ? GameObject.FindObjectsOfType<GameObject>() : GameObject.FindGameObjectsWithTag(tagName);
		gameObjects = GetGameObjectsInDistance(gameObjects, distance);
		gameObjects = GetGameObjectsInAngle(gameObjects, angle);
		gameObjects = SortGameObjectsByDistance(gameObjects);

		return gameObjects;
	}
}
