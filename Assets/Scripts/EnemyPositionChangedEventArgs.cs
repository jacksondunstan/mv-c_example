using System;

using UnityEngine;

public class EnemyPositionChangedEventArgs : EventArgs
{
	public Vector3 Position { get; protected set; }

	public EnemyPositionChangedEventArgs(Vector3 position)
	{
		Position = position;
	}
}