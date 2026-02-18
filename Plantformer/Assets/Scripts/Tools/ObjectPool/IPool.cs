public interface IPool<T>
{
    void Prewarm(int num);//预热
    T Request();//供应
    void Return(T member);//回收
}