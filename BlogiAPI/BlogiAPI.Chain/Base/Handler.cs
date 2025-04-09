using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogiAPI.Domain.Services;

namespace BlogiAPI.Chain.Base
{
    public abstract class Handler<T>
    {
        protected Handler<T>? NextHandler;

        public void SetNext(Handler<T>? handler)
        {
            NextHandler = handler;
        }

        public abstract Task<OperationResult> HandleRequest(T request);
    }
}


