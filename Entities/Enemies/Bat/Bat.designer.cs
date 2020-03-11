using Godot;

namespace LoZMM.Entities.Enemies.Bat {
	public partial class Bat {
		protected AnimationPlayer AnimationPlayer => GetNode<AnimationPlayer>("AnimationPlayer");
	}
}