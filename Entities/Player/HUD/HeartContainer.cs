using System.Linq;
using Godot;

namespace LoZMM.Entities.Player.HUD {
	public class HeartContainer : Node2D {
		public Player GetPlayer() => GetTree().GetNodesInGroup("player").Cast<Player>().FirstOrDefault();

		public override void _Process(float delta) {
			var player = GetPlayer();
			if (player == null) return;

			for (var i = 0; i < GetChildCount(); i++) {
				var minValue = i*4 + 1;
				var heart = GetChild<Sprite>(i);
				heart.Visible = player.MaxHealth >= minValue;

				if (player.Health >= minValue + 4) {
					heart.Frame = 4;
				}
				else if (player.Health <= minValue - 1) {
					heart.Frame = 0;
				}
				else {
					heart.Frame = player.Health - minValue + 1;
				}
			}
		}
	}
}
