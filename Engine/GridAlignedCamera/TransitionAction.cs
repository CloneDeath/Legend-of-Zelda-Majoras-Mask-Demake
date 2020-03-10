using Godot;
using LegendsOfLove.Entities.Player;

namespace LegendsOfLove.Engine.GridAlignedCamera {
	public class TransitionAction {
		public Player Player { get; }
		public Vector2 Direction { get; }

		public TransitionAction(Player player, Vector2 direction) {
			Player = player;
			Direction = direction;
		}
	}
}