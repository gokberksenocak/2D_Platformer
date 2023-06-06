namespace Project.Abstracts.Inputs
{
    public interface IPlayerInput
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool IsJumpPressed { get; }
    }
}