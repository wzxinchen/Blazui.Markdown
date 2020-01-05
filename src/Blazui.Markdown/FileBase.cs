using Blazui.Component;
using Blazui.Component.Form;
using Blazui.Markdown.IconHandlers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazui.Markdown
{
    public class FileBase : BComponentBase
    {
        internal protected BForm form;

        [Parameter]
        public string UploadUrl { get; set; }

        /// <summary>
        /// 单文件最大限制，KB为单位
        /// </summary>
        [Parameter]
        public long MaxSize { get; set; }

        /// <summary>
        /// 允许上传的文件后缀
        /// </summary>
        [Parameter]
        public string[] AllowExtensions { get; set; }
        internal protected void Submit()
        {
            if (!form.IsValid())
            {
                return;
            }
            _ = DialogService.CloseDialogAsync(this, form.GetValue<FileModel>());
        }
    }
}
