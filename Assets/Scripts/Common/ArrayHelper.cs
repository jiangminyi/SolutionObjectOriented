﻿using ns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 扩展方法：能够向现有类添加方法，而无需修改原始类代码。
 作用：使调用者可以像调用自身实例方法一样方便。
 注意：
      1. 扩展方法必须在非泛型的静态类中。
      2. 使用this关键字修改第一个参数
     */
namespace Common
{
    /// <summary>
    /// 数组助手类：封装开发中对数组的常用操作
    /// </summary>
    public static class ArrayHelper
    {
        /// <summary>
        /// 获取对象数组中，满足条件的最大元素。
        /// </summary>
        /// <typeparam name="T">对象数组的元素类型 例如：Enemy</typeparam>
        /// <typeparam name="Q">条件的类型 例如：int</typeparam>
        /// <param name="array">对象数组 例如：Enemy[]</param>
        /// <param name="condition">条件 例如：HP</param>
        /// <returns></returns>
        public static T GetMax<T, Q>(this T[] array, Func<T, Q> condition) where Q : IComparable
        {
            var max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                //if (max.HP < array[i].HP)
                //if(condition(max) < condition(array[i])) 
                if (condition(max).CompareTo(condition(array[i])) < 0)
                {
                    max = array[i];
                }
            }
            return max;
        }

        /// <summary>
        /// 获取对象数组中，满足条件的最小元素。
        /// </summary>
        /// <typeparam name="T">对象数组的元素类型 例如：Enemy</typeparam>
        /// <typeparam name="Q">条件的类型 例如：int</typeparam>
        /// <param name="array">对象数组 例如：Enemy[]</param>
        /// <param name="condition">条件 例如：HP</param>
        /// <returns></returns>
        public static T GetMin<T, Q>(this T[] array, Func<T, Q> condition) where Q : IComparable
        {
            var min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (condition(min).CompareTo(condition(array[i])) > 0)
                {
                    min = array[i];
                }
            }
            return min;
        }

        /// <summary>
        /// 在对象数组中查找满足条件的所有元素
        /// </summary>
        /// <typeparam name="T">对象数组元素类型</typeparam>
        /// <param name="array">对象数组</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static T[] FindAll<T>(this T[] array, Func<T, bool> condition)
        {
            List<T> list = new List<T>(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                //if (array[i].HP > 0)
                //if(Fun2(array[i]))
                if (condition(array[i]))
                {
                    list.Add(array[i]);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// 在对象数组中查找满足条件的单个元素
        /// </summary>
        /// <typeparam name="T">对象数组元素类型</typeparam>
        /// <param name="array">对象数组</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static T Find<T>(this T[] array, Func<T, bool> condition)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    return array[i];
                }
            }
            return default(T); //返回该类型默认值
        }

        /// <summary>
        /// 对象数组升序排列
        /// </summary>
        /// <typeparam name="T">对象数组的元素类型 例如：Enemy</typeparam>
        /// <typeparam name="Q">条件的类型 例如：int</typeparam>
        /// <param name="array">对象数组 例如：Enemy[]</param>
        /// <param name="condition">条件 例如：HP</param>
        public static void OrderBy<T, Q>(this T[] array, Func<T, Q> condition) where Q : IComparable
        {
            for (int r = 0; r < array.Length - 1; r++)
            {
                for (int c = r + 1; c < array.Length; c++)
                {
                    //if (array[r].HP > array[c].HP)
                    //if(condition(array[r]) > condition(array[c]))
                    if (condition(array[r]).CompareTo(condition(array[c])) > 0)
                    {
                        var temp = array[r];
                        array[r] = array[c];
                        array[c] = temp;
                    }
                }
            }

        }

        /// <summary>
        /// 对象数组降序排列
        /// </summary>
        /// <typeparam name="T">对象数组的元素类型 例如：Enemy</typeparam>
        /// <typeparam name="Q">条件的类型 例如：int</typeparam>
        /// <param name="array">对象数组 例如：Enemy[]</param>
        /// <param name="condition">条件 例如：HP</param>
        public static void OrderByDescending<T, Q>(this T[] array, Func<T, Q> condition) where Q : IComparable
        {
            for (int r = 0; r < array.Length - 1; r++)
            {
                for (int c = r + 1; c < array.Length; c++)
                {
                    if (condition(array[r]).CompareTo(condition(array[c])) < 0)
                    {
                        var temp = array[r];
                        array[r] = array[c];
                        array[c] = temp;
                    }
                }
            }
        }

        //GameObject[]          Transform[]       Enemy[]  ……
        public static Q[] Select<T,Q>(this T[] array,Func<T,Q> handler)
        {
            Q[] result = new Q[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                //result[i] = array[i].transform; 
                result[i] = handler(array[i]);
            }

            return result;
        }
    }
}
