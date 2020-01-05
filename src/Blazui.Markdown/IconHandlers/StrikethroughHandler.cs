using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazui.Markdown.IconHandlers
{
    public class StrikethroughHandler : IIconHandler
    {
        private readonly IJSRuntime jSRuntime;

        public StrikethroughHandler(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public void Handle(ElementReference textarea)
        {
            jSRuntime.InvokeVoidAsync("wrapSelection", textarea, "~~", "~~");
        }
    }
}
