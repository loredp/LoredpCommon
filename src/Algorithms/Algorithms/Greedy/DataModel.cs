using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Greedy
{
    public class DataModel
    {
        /// <summary>
        /// 权重
        /// </summary>
        public float weight { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public float value { get; set; }

        public bool mark { get; set; }

        public char char_mark { get; set; }

        public float pre_weight_value { get; set; } 
    }
}
