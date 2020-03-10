using Godot;

namespace LegendsOfLove.Engine.GridAlignedCamera {
	public partial class GridAlignedCamera {
		protected Tween Tween => GetNode<Tween>("Tween");
		protected Camera2D Camera2D => GetNode<Camera2D>("Camera2D");
		protected AnimationPlayer AnimationPlayer => GetNode<AnimationPlayer>("AnimationPlayer");
	}
}