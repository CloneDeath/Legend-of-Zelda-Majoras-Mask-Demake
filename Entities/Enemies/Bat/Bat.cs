using System.Linq;
using Godot;

namespace LoZMM.Entities.Enemies.Bat {
	public partial class Bat : BaseEntity.BaseEntity, IHammerable {
		[Export] public float Speed = 16f;
		protected Vector2 Direction;

		protected float ChangeDirections;

		public override void Unfreeze() {
			base.Unfreeze();
			RandomizeDirection();
		}

		public override void _Ready() {
			base._Ready();
			RandomizeDirection();
		}

		protected void RandomizeDirection() {
			ChangeDirections = (GD.Randi() % 3) + 1;
			var player = GetTree().GetNodesInGroup("player").Cast<Player.Player>().FirstOrDefault();
			
			var delta = GetVariance();
			if (GD.Randi() % 2 == 0 && player != null) {
				Direction = GlobalPosition.DirectionTo(player.GlobalPosition).Rotated(delta);
			}
			else {
				Direction = GetRandomDirection().Rotated(delta);
			}
		}

		public override void _Process(float delta) {
			if (IsFrozen) {
				AnimationPlayer.Stop();
			}
			else {
				AnimationPlayer.Play();
				ChangeDirections -= delta;
				if (ChangeDirections <= 0) {
					RandomizeDirection();
				}
			}
			base._Process(delta);
			if (IsOnWall()) {
				Direction = GetRandomDirection();
			}
		}

		protected float GetVariance() {
			const float variance = 0.25f;
			const float varianceRadians = 2 * Mathf.Pi * variance;
			return (((GD.Randi() % 100)/100.0f) * varianceRadians) - (varianceRadians / 2.0f);
		}

		public override void Damage(Vector2 direction) {
			base.Damage(direction);

			var delta = GetVariance();
			Direction = direction.Rotated(delta);
		}

		protected override Vector2 GetVelocity() {
			return Direction.Normalized() * Speed;
		}

		public void Hammer(Vector2 direction) {
			if (Health > 1) Health = 1;
			Damage(direction);
		}
	}
}
