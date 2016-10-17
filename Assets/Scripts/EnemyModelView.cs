using System;

using UnityEngine;

// The combined model (data representation) and view (input and output) for an enemy. Does no logic.
public class EnemyModelView : MonoBehaviour, IEnemyModelView
{
	// Data events
	public event EventHandler<EnemyHealthChangedEventArgs> OnHealthChanged = (s, e) => {};
	public event EventHandler<EnemyPositionChangedEventArgs> OnPositionChanged = (s, e) => {};

	// Input events
	public event EventHandler<EnemyClickedEventArgs> OnClicked = (s, e) => {};

	// Data stored by the model-view
	// Outputs the data by mapping it to the material color
	private float health;
	public float Health
	{
		get { return health; }
		set
		{
			if (value != health)
			{
				health = value;
				GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.green, value);
				OnHealthChanged(this, new EnemyHealthChangedEventArgs(health));
			}
		}
	}

	// Wrapper for data already stored by Unity
	// Outputs the data by direct pass-through: no logic
	public Vector3 Position
	{
		get { return transform.position; }
		set
		{
			if (value != transform.position)
			{
				transform.position = value;
				OnPositionChanged(this, new EnemyPositionChangedEventArgs(value));
			}
		}
	}

	// Default values can be set where appropriate
	void Awake()
	{
		Health = 1;
	}

	// Handle input by dispatching an event, not performing logic
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit) && hit.transform == transform)
			{
				OnClicked(this, new EnemyClickedEventArgs());
			}
		}
	}

	// Destroy the enemy, but we don't know why
	public void Destroy()
	{
		Destroy(gameObject);
	}
}