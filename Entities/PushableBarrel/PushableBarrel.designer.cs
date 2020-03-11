using Godot;

namespace LoZMM.Entities.PushableBarrel {
	public partial class PushableBarrel {
		protected AnimationPlayer AnimationPlayer => GetNode<AnimationPlayer>("AnimationPlayer");
		protected Tween MovementTween => GetNode<Tween>("MovementTween");
	}
}