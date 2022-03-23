using Xunit;

namespace Xde.Flow
{
    public class DisposableChainSpecs
    {
        public class CustomDisposable : IDisposable
        {
            public bool Disposed { get; set; } = false;

            public void Dispose() => Disposed = true;
        }

        public class CustomDisposable1 : CustomDisposable { };

        public class CustomDisposable2 : CustomDisposable { };

        [Fact]
        public void Ctor_NullDisposable_ThrowException()
        {
            var e = Assert.Throws<ArgumentNullException>(
                () => new DisposableChain<IDisposable>(null)
            );

            Assert.Equal("disposable", e.ParamName);
        }

        [Fact]
        public void Ctor_HasDisposable_HasBeenDisposed()
        {
            var disposable = new CustomDisposable();

            IDisposable chain = new DisposableChain<CustomDisposable>(disposable);
            chain.Dispose();

            Assert.True(disposable.Disposed);
        }

        [Fact]
        public void Next_SecondValue_HaveBeenDisposed()
        {
            var disposable1 = new CustomDisposable1();
            var disposable2 = new CustomDisposable2();

            IDisposable chain = new DisposableChain<CustomDisposable1>(disposable1)
                .Next(disposable2)
            ;

            Assert.False(disposable1.Disposed);
            Assert.False(disposable2.Disposed);

            chain.Dispose();

            Assert.True(disposable1.Disposed);
            Assert.True(disposable2.Disposed);
        }

        [Fact]
        public void Next_DisposableExtendedWithValue_HaveBeenDisposed()
        {
            var disposable1 = new CustomDisposable1();
            var disposable2 = new CustomDisposable2();

            IDisposable chain = disposable1
                .Next(disposable2)
            ;

            Assert.False(disposable1.Disposed);
            Assert.False(disposable2.Disposed);

            chain.Dispose();

            Assert.True(disposable1.Disposed);
            Assert.True(disposable2.Disposed);
        }

        [Fact]
        public void Next_DisposableExtendedWithFunc_HaveBeenDisposed()
        {
            var disposable1 = new CustomDisposable1();
            var disposable2 = new CustomDisposable2();

            IDisposable chain = disposable1
                .Next(item => disposable2)
            ;

            Assert.False(disposable1.Disposed);
            Assert.False(disposable2.Disposed);

            chain.Dispose();

            Assert.True(disposable1.Disposed);
            Assert.True(disposable2.Disposed);
        }

        //TODO:
        public void Sample()
        {
            new FileStream("some path", FileMode.Open)
                .Next(file => new StreamReader(file))
            ;
        }
    }
}
