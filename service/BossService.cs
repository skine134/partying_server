namespace partying_server.service
{
    public class BossService
    {
        public static void AttackedBoss(float damage)
        {
            Info.BossInfo.BossHP -= damage;
        }
    }
}