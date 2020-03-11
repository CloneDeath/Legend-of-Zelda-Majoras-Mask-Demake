namespace LoZMM.Entities.Items.Sword {
	public class Sword : BaseEntity.BaseEntity, IItemPickup
	{
		public void OnPickup(Entities.Player.Player player) {
			player.HasSword = true;
			player.Play("Get_Sword");
			QueueFree();
		}
	}
}
