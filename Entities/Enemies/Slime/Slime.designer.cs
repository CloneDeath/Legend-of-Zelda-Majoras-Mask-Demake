using Godot;

namespace LoZMM.Entities.Enemies.Slime {
	public partial class Slime {
		public AnimationPlayer Idle => GetNode<AnimationPlayer>("Idle");
	}
}