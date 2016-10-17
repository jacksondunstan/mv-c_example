using NSubstitute;
using NUnit.Framework;

#pragma warning disable 0168, 0219 // unused variables

// Class with tests
[TestFixture]
public class TestEnemyController
{
	// A single test
	[Test]
	public void ReducesHealthByClickDamageWhenClicked()
	{
		// Make a fake model-view and give it to a real controller
		var modelView = Substitute.For<IEnemyModelView>();
		modelView.Health = 1;
		var controller = new EnemyController(modelView, 0.25f);

		// Fake the OnClicked event
		modelView.OnClicked += Raise.EventWith(new EnemyClickedEventArgs());

		// Make sure the controller damaged the enemy
		Assert.That(modelView.Health, Is.EqualTo(0.75f).Within(0.001f));
	}

	// Three tests in one. Specify parameters for each run of this function.
	[TestCase(0.1f,  0)]
	[TestCase(0,     1)]
	[TestCase(-0.1f, 1)]
	public void OnlyDestroysWhenHealthChangesToLessThanOrEqualToZero(
		float health,
		int numDestroyCalls
	)
	{
		// Make a fake model-view and give it to a real controller
		var modelView = Substitute.For<IEnemyModelView>();
		modelView.Health = 1;
		var controller = new EnemyController(modelView, 0.25f);

		// Fake the OnHealthChanged event
		modelView.OnHealthChanged += Raise.EventWith(new EnemyHealthChangedEventArgs(health));

		// Make sure the controller called Destroy() the right number of times
		modelView.Received(numDestroyCalls).Destroy();
	}
}