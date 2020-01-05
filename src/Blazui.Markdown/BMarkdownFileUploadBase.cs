using Blazui.Component;
using Blazui.Component.Form;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blazui.Markdown
{
    public class BMarkdownFileUploadBase : BFieldComponentBase<string[]>
    {
        /// <summary>
        /// 上传地址
        /// </summary>
        [Parameter]
        public string UploadUrl { get; set; }

        /// <summary>
        /// 文件地址列表
        /// </summary>
        [Parameter]
        public string[] Urls { get; set; }

        [Parameter]
        public EventCallback<string[]> UrlsChanged { get; set; }

        protected internal void UpdateFiles(IFileModel[] files)
        {
            Urls = files.Select(x => x.Url).ToArray();
            if (UrlsChanged.HasDelegate)
            {
                _ = UrlsChanged.InvokeAsync(Urls);
            }
            RequireRender = true;
            SetFieldValue(Urls, true);
        }
        protected internal void OnDeleteFile(IFileModel file)
        {
            Urls = Urls.Where(x => x != file.Url).ToArray();
            if (UrlsChanged.HasDelegate)
            {
                _ = UrlsChanged.InvokeAsync(Urls);
            }
            RequireRender = true;
            SetFieldValue(Urls, true);
        }
        protected internal void UpdateUrl(string file)
        {
            Urls = new string[] { file };
            if (UrlsChanged.HasDelegate)
            {
                _ = UrlsChanged.InvokeAsync(Urls);
            }
            RequireRender = true;
            SetFieldValue(Urls, true);
        }
    }
}
