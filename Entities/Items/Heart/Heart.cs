using System;

namespace LegendsOfLove.Entities.Items.Heart {
	public class Heart : BaseEntity.BaseEntity, IItemPickup
	{
		public override void _Ready() {
		}

		public override void Reset() {
			base.Reset();
			QueueFree();
		}

		public void OnPickup(Player.Player player) {
			player.Health = Math.Min(player.Health + 1, player.MaxHealth);
			player.PickupHeartSound.Play();
			QueueFree();
		}
	}
}
