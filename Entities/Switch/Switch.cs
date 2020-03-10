using Godot;

namespace LegendsOfLove.Entities.Switch {
	public class Switch : Area2D {
		[Signal] public delegate void Pressed();
		[Signal] public delegate void Released();

		protected void _on_Switch_body_entered(Node body) {
			EmitSignal(nameof(Pressed));
		}

		protected void _on_Switch_body_exited(Node body) {
			EmitSignal(nameof(Released));
		}
	}
}
