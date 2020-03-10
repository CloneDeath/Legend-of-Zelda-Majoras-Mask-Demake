namespace LegendsOfLove.Entities.Items.Sword {
	public class Sword : BaseEntity.BaseEntity, IItemPickup
	{
		public void OnPickup(Player.Player player) {
			player.HasSword = true;
			player.Play("Get_Sword");
			QueueFree();
		}
	}
}
