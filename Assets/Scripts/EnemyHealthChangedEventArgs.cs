using System;

public class EnemyHealthChangedEventArgs : EventArgs
{
	public float Health { get; private set; }

	public EnemyHealthChangedEventArgs(float health)
	{
		Health = health;
	}
}