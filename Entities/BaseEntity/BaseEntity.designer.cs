using Godot;

namespace LoZMM.Entities.BaseEntity {
	public partial class BaseEntity {
		protected Sprite Sprite => GetNode<Sprite>("Sprite");
		protected Sprite DeathSprite => GetNode<Sprite>("DeathSprite");
		protected Timer InvulnerabilityTimer => GetNode<Timer>("InvulnerabilityTimer");
		protected AnimationPlayer KnockbackAnimation => GetNode<AnimationPlayer>("KnockbackAnimation");
	}
}