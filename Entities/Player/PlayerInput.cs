using Godot;

namespace LoZMM.Entities.Player {
	public class PlayerInput {
		private readonly bool _frozen;

		public PlayerInput(bool frozen) {
			_frozen = frozen;
		}
		
		public bool MoveLeft => !_frozen && Input.IsActionPressed("move_left");
		public bool MoveRight => !_frozen && Input.IsActionPressed("move_right");
		public bool MoveUp => !_frozen && Input.IsActionPressed("move_up");
		public bool MoveDown => !_frozen && Input.IsActionPressed("move_down");

		public bool Attack => !_frozen && Input.IsActionJustPressed("attack");
		public bool Hammer => !_frozen && Input.IsActionJustPressed("hammer");

		public Vector2 MoveVector {
			get {
				var left = MoveLeft ? -1 : 0;
				var right = MoveRight ? 1 : 0;
				var up = MoveUp ? -1 : 0;
				var down = MoveDown ? 1 : 0;

				return new Vector2(left + right, up + down);
			}
		}
	}
}