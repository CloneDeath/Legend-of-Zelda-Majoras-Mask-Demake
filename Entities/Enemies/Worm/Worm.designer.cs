using Godot;

namespace LoZMM.Entities.Enemies.Worm {
	public partial class Worm {
		protected AnimationPlayer Animation => GetNode<AnimationPlayer>("Animation");
	}
}