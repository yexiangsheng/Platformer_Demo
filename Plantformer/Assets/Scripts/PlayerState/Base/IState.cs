/// <summary>
/// 接口类，定义一个状态一定有的方法
/// </summary>
public interface IState 
{
    void Enter();
    void Exit();
    void LogicUpdate();
    void PhysicUpdate();
}
