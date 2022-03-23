namespace Xde.Flow
{
    public static class DisposableChainExtensions
    {
        public static DisposableChain<TTarget> Next<TSource, TTarget>(
            this TSource disposable,
            Func<TSource, TTarget> next
        )
            where TSource : IDisposable
            where TTarget : IDisposable
            => new DisposableChain<TSource>(disposable).Next(next)
        ;

        public static DisposableChain<TTarget> Next<TSource, TTarget>(
            this TSource disposable,
            TTarget next
        )
            where TSource : IDisposable
            where TTarget : IDisposable
            => new DisposableChain<TSource>(disposable).Next(next)
        ;
    }
}
