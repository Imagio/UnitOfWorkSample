using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ru.Rubinst.DesignPatterns
{
    public class Singleton<T> where T : class
    {
        protected Singleton() { }

        private sealed class SingletonCreator<TS> where TS : class
        {
            private static readonly TS _instance = (TS) typeof (TS).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new Type[0],
                new ParameterModifier[0]).Invoke(null);

            public static TS CreatorInstance
            {
                get { return _instance; }
            }
        }

        public static T Instance
        {
            get { return SingletonCreator<T>.CreatorInstance; }
        }
    }
}
