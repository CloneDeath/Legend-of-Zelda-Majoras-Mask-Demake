using Godot;

namespace LoZMM.Engine.GridAlignedCamera {
	public partial class GridAlignedCamera {
		protected Tween Tween => GetNode<Tween>("Tween");
		protected Camera2D Camera2D => GetNode<Camera2D>("Camera2D");
		protected AnimationPlayer AnimationPlayer => GetNode<AnimationPlayer>("AnimationPlayer");

		protected CollisionShape2D ContentsShape => GetNode<CollisionShape2D>("ContentsArea2D/ContentsShape");
		protected NonPlayerEntityBounds NonPlayerEntityBounds => GetNode<NonPlayerEntityBounds>("NonPlayerEntityBounds");

		protected CollisionShape2D TopEdge => GetNode<CollisionShape2D>("TopArea2D/TopEdge");
		protected CollisionShape2D BottomEdge => GetNode<CollisionShape2D>("BottomArea2D/BottomEdge");
		protected CollisionShape2D LeftEdge => GetNode<CollisionShape2D>("LeftArea2D/LeftEdge");
		protected CollisionShape2D RightEdge => GetNode<CollisionShape2D>("RightArea2D/RightEdge");
	}
}