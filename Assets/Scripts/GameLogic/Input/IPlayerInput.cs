namespace GameLogic.Input
{
    public interface IPlayerInput
    {
        public bool IsShoot();
        public bool IsLaserShoot();
        public bool IsStartMove();
        public bool IsStopMove();
        public bool IsRotateLeftMove();
        public bool IsRotateRightMove();
    }
}