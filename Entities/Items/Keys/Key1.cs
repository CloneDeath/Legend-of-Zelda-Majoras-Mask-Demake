namespace LegendsOfLove.Entities.Items.Keys {
	public class Key1 : BaseEntity.BaseEntity, IItemPickup
	{
		public void OnPickup(Player.Player player) {
			player.HasKey1 = true;
			player.Play("Get_Key");
			QueueFree();
		}
	}
}
