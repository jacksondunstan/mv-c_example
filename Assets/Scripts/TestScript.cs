using System;

using UnityEngine;

public class TestScript : MonoBehaviour
{
	void Awake()
	{
		// Create the model-view
		var prefab = Resources.Load<GameObject>("Enemy");
		var instance = Instantiate(prefab);
		var modelView = instance.GetComponent<IEnemyModelView>();
		modelView.Position = new Vector3(1, 2, 3);

		// Create the controller
		// No need to keep a reference because the model-view already has at least one
		new EnemyController(modelView, 0.25f);
	}
}