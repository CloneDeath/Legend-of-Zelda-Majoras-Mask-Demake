using Godot;
using LoZMM.Entities.Items.MaxHealthUp;

namespace LoZMM.Entities.Enemies.Worm {
	public partial class Worm : BaseEntity.BaseEntity, IHammerable {
		[Export] public bool DropsMaxHeartOnDeath { get; set; } = true;
		
		protected bool IsAboveGround => Animation.CurrentAnimation == "Above";
		protected bool IsBelowGround => Animation.CurrentAnimation == "Below";
		protected bool IsDigging => Animation.CurrentAnimation == "Dig";
		protected bool IsRising => Animation.CurrentAnimation == "Rise";

		private float _changeDirection;
		private Vector2 _direction;

		private float _modeChange = 10;

		public override void Reset() {
			base.Reset();
			RandomizeDirection();
			Animation.Play("Above");
		}

		protected override Vector2 GetVelocity() {
			if (IsRising || IsDigging) return Vector2.Zero;
			var speed = IsAboveGround ? 12.0f : 4.0f;
			if (Health < 4) {
				speed = IsAboveGround ? 14.0f : 8.0f;
			}
			else if (Health < 2) {
				speed = IsAboveGround ? 18.0f : 24.0f;
			}
			return _direction.Normalized() * speed;
		}

		public override void _Process(float delta) {
			base._Process(delta);


			if (IsFrozen) {
				Animation.Stop();
			}
			else {
				if (!(IsRising || IsDigging)) Animation.Play();
			}

			if (!IsFrozen) {
				if (IsOnWall()) {
					_direction = GetRandomDirection();
				}
				_changeDirection -= delta;
				if (_changeDirection <= 0) {
					RandomizeDirection();
				}

				if (IsAboveGround || IsBelowGround) {
					_modeChange -= delta;
					if (_modeChange <= 0) {
						_modeChange = (GD.Randi() % 5) + 5;
						if (IsAboveGround) {
							Animation.Play("Dig");
						}
						else {
							Animation.Play("Rise");
						}
					}
				}
			}
		}

		private void RandomizeDirection() {
			_direction = GetRandomDirection();
			_changeDirection = GD.Randi() % 2 + 3;
		}

		public override void Damage(Vector2 direction) {
			if (IsBelowGround || IsDigging) return;
			base.Damage(direction);
			_modeChange -= 5;
		}

		public void Hammer(Vector2 direction) {
			base.Damage(direction);
			if (IsBelowGround) _modeChange = 0;
		}

		public override void OnDeath() {
			base.OnDeath();

			if (DropsMaxHeartOnDeath) {
				var heart = (MaxHealthUp) ResourceLoader.Load<PackedScene>("res://Entities/Items/MaxHealthUp/MaxHealthUp.tscn").Instance();
				GetParent().AddChild(heart);
				heart.Position = Position;
			}
			QueueFree();
		}
	}
}
