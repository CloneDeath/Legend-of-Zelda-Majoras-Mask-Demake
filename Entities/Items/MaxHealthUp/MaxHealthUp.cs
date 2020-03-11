namespace LoZMM.Entities.Items.MaxHealthUp {
	public class MaxHealthUp : BaseEntity.BaseEntity, IItemPickup
	{
		public void OnPickup(Entities.Player.Player player) {
			player.MaxHealth += 1;
			player.Health = player.MaxHealth;
			player.Play("Get_Heart");
			QueueFree();
		}
	}
}
