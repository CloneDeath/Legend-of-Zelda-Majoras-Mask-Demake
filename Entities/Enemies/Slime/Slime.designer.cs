using Godot;

namespace LegendsOfLove.Entities.Enemies.Slime {
	public partial class Slime {
		public AnimationPlayer Idle => GetNode<AnimationPlayer>("Idle");
	}
}