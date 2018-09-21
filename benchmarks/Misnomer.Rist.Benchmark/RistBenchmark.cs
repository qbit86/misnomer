using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;

namespace Misnomer
{
    [MemoryDiagnoser]
    public abstract class RistBenchmark
    {
        // https://en.wikipedia.org/wiki/Collatz_conjecture
        private static int GetNext(int n)
        {
            return n % 2 == 0 ? n / 2 : 3 * n + 1;
        }

        [Benchmark(Baseline = true)]
        public long List()
        {
            var list = new List<int>();

            return MaxTrajectoryPoint(list);
        }

        [Benchmark]
        public long Rist()
        {
            var rist = new Rist<int>();

            return MaxTrajectoryPoint(rist);
        }

        private long MaxTrajectoryPoint(IList<int> list)
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
                    list.RemoveRange(current, list.Count - current);
                    list.TrimExcess();
                }
                else if (current > list.Count)
                {
                    if (current > list.GetCapacity())
                        list.SetCapacity(current);

                    int newCount = current - list.Count;
                    for (int i = 0; i != newCount; ++i)
                        list.Add(step);
                }

                if (current == 1)
                    break;
            }

            Debug.Assert(list.Count > 0);
            return list[list.Count - 1] << 32 + max;
        }
    }

    internal static class ListExtensions
    {
        internal static int GetCapacity(this IList<int> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list is List<int> l)
                return l.Capacity;

            if (list is Rist<int> r)
                return r.Capacity;

            throw new NotSupportedException();
        }

        internal static void SetCapacity(this IList<int> list, int capacity)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list is List<int> l)
                l.Capacity = capacity;
            else if (list is Rist<int> r)
                r.Capacity = capacity;
            else
                throw new NotSupportedException();
        }

        internal static void RemoveRange(this IList<int> list, int index, int count)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list is List<int> l)
                l.RemoveRange(index, count);
            else if (list is Rist<int> r)
                r.RemoveRange(index, count);
            else
                throw new NotSupportedException();
        }

        internal static void TrimExcess(this IList<int> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list is List<int> l)
                l.TrimExcess();
            else if (list is Rist<int> r)
                r.TrimExcess();
            else
                throw new NotSupportedException();
        }
    }
}
