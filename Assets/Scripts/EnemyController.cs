// The logic for an enemy. Relies on a model-view to store the data representation, gather input,
// and output to the user.
public class EnemyController
{
	private readonly IEnemyModelView modelView;
	private float clickDamage;

	public EnemyController(IEnemyModelView modelView, float clickDamage)
	{
		this.modelView = modelView;
		this.clickDamage = clickDamage;

		// Listen to input from the model-view
		modelView.OnClicked += HandleClicked;

		// Listen to changes in the model-view's data
		modelView.OnHealthChanged += HandleHealthChanged;
	}

	private void HandleClicked(object sender, EnemyClickedEventArgs e)
	{
		// Perform logic as a result of this input
		// Here it's just a simple calculation to damage the enemy by reducing its health
		// Update the model-view's data representation accordingly if this is the case
		modelView.Health -= clickDamage;
	}

	private void HandleHealthChanged(object sender, EnemyHealthChangedEventArgs e)
	{
		// Perform logic as a result of this data change
		// Here it's just a simple rule that an enemy with no health is dead and gets destroyed
		// Output to the model-view accordingly if this is the case
		if (e.Health <= 0)
		{
			modelView.Destroy();
		}
	}
}