using System;

using UnityEngine;

// Interface for the model-view
public interface IEnemyModelView
{
	// Dispatched when the health changes
	event EventHandler<EnemyHealthChangedEventArgs> OnHealthChanged;

	// Dispatched when the position changes
	event EventHandler<EnemyPositionChangedEventArgs> OnPositionChanged;

	// Dispatched when the enemy is clicked
	event EventHandler<EnemyClickedEventArgs> OnClicked;

	// Position of the enemy
	Vector3 Position { get; set; }

	// Health of the enemy
	float Health { get; set; }

	// Destroy the enemy
	void Destroy();
}