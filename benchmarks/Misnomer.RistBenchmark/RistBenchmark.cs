using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;

namespace Misnomer
{
    public abstract class RistBenchmark
    {
        // https://en.wikipedia.org/wiki/Collatz_conjecture
        private static int GetNext(int n)
        {
            return n % 2 == 0 ? n / 2 : 3 * n + 1;
        }

        private static long MaxTrajectoryPoint<TList, TListPolicy>(TList list, TListPolicy p)
            where TList : IList<int>
            where TListPolicy : IListPolicy<TList>
        {
            Debug.Assert(list != null);
            list.Add(0);

            const int start = 255;

            int max = start;
            int current = start;
            for (int step = 1;; ++step)
            {
                current = GetNext(current);

                if (current > max)
                    max = current;

                if (current < list.Count)
                {
                    p.RemoveRange(list, current, list.Count - current);
                    p.TrimExcess(list);
                }
                else if (current > list.Count)
                {
                    if (current > p.GetCapacity(list))
                        p.SetCapacity(list, current);

                    int newCount = current - list.Count;
                    for (int i = 0; i != newCount; ++i)
                        list.Add(step);
                }

                if (current == 1)
                    break;
            }

            Debug.Assert(list.Count > 0);
            return ((long)list[list.Count - 1] << 32) + max;
        }

#pragma warning disable CA1822
        [Benchmark(Baseline = true)]
        public long List()
        {
            return MaxTrajectoryPoint(new List<int>(), new ListPolicy());
        }

        [Benchmark]
        public long Rist()
        {
            return MaxTrajectoryPoint(new Rist<int>(), new RistPolicy());
        }
#pragma warning restore CA1822
    }

    internal interface IListPolicy<in TList>
    {
        int GetCapacity(TList list);
        void SetCapacity(TList list, int capacity);
        void RemoveRange(TList list, int index, int count);
        void TrimExcess(TList list);
    }

    internal struct ListPolicy : IListPolicy<List<int>>
    {
        public int GetCapacity(List<int> list)
        {
            return list.Capacity;
        }

        public void SetCapacity(List<int> list, int capacity)
        {
            list.Capacity = capacity;
        }

        public void RemoveRange(List<int> list, int index, int count)
        {
            list.RemoveRange(index, count);
        }

        public void TrimExcess(List<int> list)
        {
            list.TrimExcess();
        }
    }

    internal struct RistPolicy : IListPolicy<Rist<int>>
    {
        public int GetCapacity(Rist<int> list)
        {
            return list.Capacity;
        }

        public void SetCapacity(Rist<int> list, int capacity)
        {
            list.Capacity = capacity;
        }

        public void RemoveRange(Rist<int> list, int index, int count)
        {
            list.RemoveRange(index, count);
        }

        public void TrimExcess(Rist<int> list)
        {
            list.TrimExcess();
        }
    }
}
