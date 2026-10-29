
public interface IGameCommand
{
    bool Execute();
    void Undo();
}