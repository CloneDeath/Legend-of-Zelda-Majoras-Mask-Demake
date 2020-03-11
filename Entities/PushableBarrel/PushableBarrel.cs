using Godot;

namespace LoZMM.Entities.PushableBarrel {
	public partial class PushableBarrel : BaseEntity.BaseEntity, IPushable {
		public override void _Process(float delta) {
			if (IsFrozen) {
				AnimationPlayer.Stop();
			}

			base._Process(delta);
		}

		public void Push(Vector2 direction) {
			if (MovementTween.IsActive()) return;
			if (TestMove(GlobalTransform, direction * 6)) return;

			AnimationPlayer.Play("Roll");
			StartMovementTween(direction);
		}

		protected void StartMovementTween(Vector2 direction) {
			MovementTween.RemoveAll();

			const float duration = 0.5f;
			MovementTween.InterpolateProperty(this, nameof(Position),
				Position, Position + direction * 6,  duration);
			MovementTween.Start();
		}
	}
}
