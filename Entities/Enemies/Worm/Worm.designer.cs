using Godot;

namespace LegendsOfLove.Entities.Enemies.Worm {
	public partial class Worm {
		protected AnimationPlayer Animation => GetNode<AnimationPlayer>("Animation");
	}
}