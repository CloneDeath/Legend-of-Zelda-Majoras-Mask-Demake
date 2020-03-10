using Godot;

namespace LegendsOfLove.Entities.Enemies.Bat {
	public partial class Bat {
		protected AnimationPlayer AnimationPlayer => GetNode<AnimationPlayer>("AnimationPlayer");
	}
}