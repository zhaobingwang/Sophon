using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.Faker
{
    public class RandomFaker
    {
        Randomizer _randomizer;
        public RandomFaker()
        {
            _randomizer = new Randomizer();
        }

        /// <summary>
        /// 获取一个在[<paramref name="min"/>,<paramref name="max"/>]范围内的随机数
        /// </summary>
        /// <param name="min">最小值（包含）</param>
        /// <param name="max">最大值（包含）</param>
        /// <returns></returns>
        public int GetNumber(int min, int max)
        {
            return _randomizer.Number(min, max);
        }

        public bool GetBool()
        {
            return _randomizer.Bool();
        }
    }
}
