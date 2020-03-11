using System.Linq;
using Godot;

namespace LoZMM.Entities.Player.HUD {
	public class HeartContainer : Node2D {
		public Player GetPlayer() => GetTree().GetNodesInGroup("player").Cast<Player>().FirstOrDefault();

		public override void _Process(float delta) {
			var player = GetPlayer();
			if (player == null) return;

			for (var i = 0; i < GetChildCount(); i++) {
				var value = i + 1;
				var heart = GetChild<Sprite>(i);
				heart.Visible = player.MaxHealth >= value;
				heart.Frame = player.Health >= value ? 1 : 0;
			}
		}
	}
}
