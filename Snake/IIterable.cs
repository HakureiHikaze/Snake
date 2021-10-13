namespace Snake
{
    public interface IIterable<T>
    {
        T GetElement(params int[]indexArr);
        void SetElement(T e, params int[] indexArr);
    }
}