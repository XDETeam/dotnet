namespace Xde.Flow
{
    /// TODO:Descends from the basic chain?
    public class DisposableChain<T>
        : IDisposable
        where T : IDisposable
    {
        private readonly Stack<IDisposable> _stack;

        private T _last;
        public T Last => _last;

        private DisposableChain(Stack<IDisposable> stack, T disposable)
        {
            if (disposable == null)
            {
                throw new ArgumentNullException(nameof(disposable));
            }

            _last = disposable;

            _stack = stack;
            _stack.Push(disposable);
        }

        public DisposableChain(T disposable)
            : this(new Stack<IDisposable>(), disposable)
        {
            
        }

        public DisposableChain<U> Next<U>(U disposable)
            where U : IDisposable
        {
            if (disposable == null)
            {
                //TODO:
                throw new ArgumentNullException(nameof(disposable));
            }

            return new DisposableChain<U>(_stack, disposable);
        }

        public DisposableChain<U> Next<U>(Func<T, U> next)
            where U : IDisposable
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            var disposable = next(_last);

            return Next(disposable);
        }

        void IDisposable.Dispose()
        {
            while (_stack.Count > 0)
            {
                var disposable = _stack.Pop();
                disposable.Dispose();
            }
        }
    }
}
