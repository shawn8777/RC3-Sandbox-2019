/*
 * Notes
 */

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IInitializer<T>
    {
        void Initialize(T target);
    }
}
