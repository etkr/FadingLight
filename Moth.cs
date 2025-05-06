using Godot;

namespace FadingLight;

public partial class Moth : CharacterBody2D
{
    private const float Gravity = 200.0f;
    
    public override void _PhysicsProcess(double delta)
    {
        var velocity = Velocity;
        velocity.Y += (float)delta * Gravity;
        Velocity = velocity;

        var motion = velocity * (float)delta;
        MoveAndCollide(motion);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton)
        {
            var velocity = Velocity;
            velocity.Y += 10;
            Velocity = velocity;
        }
    }
}