using Godot;

namespace FadingLight;

public partial class Moth : CharacterBody2D
{
    private static readonly Vector2 InitialVelocity = new(10, 0);
    private static readonly Vector2 Gravity = new(0, 50);
    private static readonly Vector2 FlapImpulse = new(0, -10);

    public override void _PhysicsProcess(double delta)
    {
        // Apply gravity
        Velocity += Gravity * (float)delta;

        // Detect collisions
       var collision = MoveAndCollide(Velocity * (float)delta);
       if (collision is not null)
       {
           // Restart level if collided with terrain
           GetTree().ReloadCurrentScene();
       }
    }

    public override void _Ready()
    {
        // Set initial velocity
        Velocity += InitialVelocity;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        // Flap wings when mouse or touch is pressed
        if (@event is InputEventMouseButton or InputEventScreenTouch)
        {
            // Apply upwards impulse when flapping wings
            Velocity += FlapImpulse;
        }
    }
    
    
    
}