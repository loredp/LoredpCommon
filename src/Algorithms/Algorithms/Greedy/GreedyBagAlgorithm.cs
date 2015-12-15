using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace Algorithms.Greedy
{
    public class GreedyBagAlgorithm
    {
        public void GetGreedyBagOptimal()
        {
            float[] Weight = { 35, 30, 60, 50, 40, 15, 20 };
            float[] Value = { 10, 40, 30, 50, 35, 40, 30 };
            DataModel[] arr = new DataModel[7];

            for (int i = 0; i < 7; i++)
            {
                arr[i] = new DataModel();
                arr[i].value = Value[i];
                arr[i].weight = Weight[i];
                arr[i].char_mark = Convert.ToChar(65 + i);
                arr[i].mark = false;
                arr[i].pre_weight_value = Value[i] / Weight[i];  
            }

            float weight_all = 0;
            float value_all = 0;
            float max = 0;
            char[] array = new char[7];
            int flag = 0, n = 0;

            while (weight_all <= 150)
            {
                for (int index = 0; index < 7; ++index)
                {
                    if (arr[index].pre_weight_value > max && arr[index].mark == false)
                    {
                        max = arr[index].pre_weight_value;
                        flag = index;
                    }
                }

                array[n++] = arr[flag].char_mark;
                arr[flag].mark = true;
                weight_all += arr[flag].weight;
                value_all += arr[flag].value;
                max = 0;
            }
        }
    }
}
