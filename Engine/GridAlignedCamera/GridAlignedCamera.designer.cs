using Godot;

namespace LoZMM.Engine.GridAlignedCamera {
	public partial class GridAlignedCamera {
		protected Tween Tween => GetNode<Tween>("Tween");
		protected Camera2D Camera2D => GetNode<Camera2D>("Camera2D");
		protected AnimationPlayer AnimationPlayer => GetNode<AnimationPlayer>("AnimationPlayer");

		protected CollisionShape2D ContentsShape => GetNode<CollisionShape2D>("ContentsArea2D/ContentsShape");
	}
}