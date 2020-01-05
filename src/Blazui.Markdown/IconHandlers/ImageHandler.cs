using Blazui.Component;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazui.Markdown.IconHandlers
{
    public class ImageHandler : IIconHandler
    {
        private readonly IJSRuntime jSRuntime;
        private readonly DialogService dialogService;

        public ImageHandler(IJSRuntime jSRuntime, DialogService dialogService)
        {
            this.jSRuntime = jSRuntime;
            this.dialogService = dialogService;
        }

        public async Task HandleAsync(ElementReference textarea)
        {
            var imageName = await jSRuntime.InvokeAsync<string>("getSelection", textarea);
            var imageModel = new ImageModel
            {
                Alt = imageName,
                Title = imageName
            };
            var parameters = new Dictionary<string, object>();
            parameters.Add(nameof(Image.Image), imageModel);
            parameters.Add(nameof(Image.UploadUrl), "http://localhost");
            var result = await dialogService.ShowDialogAsync<Image, ImageModel>("插入图片", parameters);
            imageModel = result.Result;
            var title = imageModel.Title;
            if (!string.IsNullOrWhiteSpace(title))
            {
                title = $"\"{title}\"";
            }
            var image = $"![{imageModel.Alt}]({imageModel.Urls} {title})";
            await jSRuntime.InvokeVoidAsync("replaceSelection", textarea, image);
        }
    }
}
