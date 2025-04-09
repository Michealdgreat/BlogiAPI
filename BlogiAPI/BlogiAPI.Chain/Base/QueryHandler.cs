namespace BlogiAPI.Chain.Base
{
    public abstract class QueryHandler<T, TU>
    {
        protected QueryHandler<T, TU>? NextHandler;

        public void SetNext(QueryHandler<T, TU>? handler)
        {
            NextHandler = handler;
        }

        public abstract Task<T?> HandleRequest(TU request);
    }
}