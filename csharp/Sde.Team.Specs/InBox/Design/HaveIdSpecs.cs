using System;
using Xunit;

namespace Sde.InBox.Design
{
    /// <summary>
    /// Identifiable contract.
    /// </summary>
    /// 
    /// <typeparam name="TKey">
    /// Type of the identifier key.
    /// </typeparam>
    /// 
    /// <remarks>
    /// <para>
    ///     TODO:Name is not good
    /// </para>
    /// </remarks>
    public interface IHaveId<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        /// 
        /// <remarks>
        /// TODO:Read-only or full-control (with runtime (IoC-time) generation of getter/setter
        /// depends on type of class) or combination of read/write/full class?
        /// </remarks>
        TKey Id { get; set; }
    }

    public static class IHaveIdExtensions
    {
        public static bool SameAs<TKey>(this IHaveId<TKey> source, IHaveId<TKey> target)
            where TKey : IEquatable<TKey>
        {
            return source.Id.Equals(target.Id);
        }
    }

    public class HaveIdSpecs
    {
        public class SomethingWithIntKey
            : IHaveId<int>
        {
            int IHaveId<int>.Id { get; set; }

            public SomethingWithIntKey(int id)
            {
                (this as IHaveId<int>).Id = id;
            }
        }

        public class SomethingWithStringKey
            : IHaveId<string>
        {
            string IHaveId<string>.Id { get; set; }

            public SomethingWithStringKey(string id)
            {
                (this as IHaveId<string>).Id = id;
            }
        }

        [Fact]
        public void Test()
        {
            var int1 = new SomethingWithIntKey(1);
            var int2 = new SomethingWithIntKey(2);

            Assert.False(int1.SameAs(int2));
        }
    }
}
