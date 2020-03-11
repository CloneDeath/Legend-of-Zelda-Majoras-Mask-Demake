namespace LoZMM.Entities.Items.Hammer {
	public class Hammer : BaseEntity.BaseEntity, IItemPickup
	{
		public void OnPickup(LoZMM.Entities.Player.Player player) {
			player.HasHammer = true;
			player.Play("Get_Hammer");
			QueueFree();
		}
	}
}
