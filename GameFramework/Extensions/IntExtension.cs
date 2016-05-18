namespace GameFramework
{
    public static class IntExtension
    {
        /// <summary>
        /// 对象转Int32
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int ToInt(this object src)
        {
            return HUtil32.ObjectToInt(src);
        }

        /// <summary>
        /// Int32转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static T ToObject<T>(this int src)
        {
            return HUtil32.IntToObject<T>(src);
        }
    }
}