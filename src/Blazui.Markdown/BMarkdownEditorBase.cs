
using Blazui.Component;
using Blazui.Component.Dom;
using Markdig;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Blazui.Markdown
{
    public class BMarkdownEditorBase : BComponentBase
    {
        internal static IDictionary<Icon, IconDescriptionAttribute> allIcons = new Dictionary<Icon, IconDescriptionAttribute>();

        internal MarkupString previewHtml = (MarkupString)string.Empty;
        internal IDictionary<Icon, IconDescriptionAttribute> icons;
        private bool editorRendered = false;
        private MarkdownPipeline pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        /// <summary>
        /// 值
        /// </summary>
        [Parameter]
        public string Value { get; set; }

        [Inject]
        private IServiceProvider serviceProvider { get; set; }
        /// <summary>
        /// 当编辑器滚动时，预览跟着滚动
        /// </summary>
        [Parameter]
        public bool EnableSyncScroll { get; set; } = true;
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        /// <summary>
        /// 工具栏图标
        /// </summary>
        [Parameter]
        public Icon[] Icons { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        [Parameter]
        public float Height { get; set; } = 500;
        internal ElementReference textarea;
        internal ElementReference preview;

        static BMarkdownEditorBase()
        {
            var iconType = typeof(Icon);
            var iconNames = Enum.GetNames(typeof(Icon));
            var handlers = Assembly.GetExecutingAssembly().GetExportedTypes()
                 .Where(x => x.IsClass)
                 .Where(x => x.Namespace.EndsWith("IconHandlers"))
                 .Where(x => x.GetInterfaces().Any(x => x == typeof(IIconHandler)))
                 .ToList();
            foreach (var iconName in iconNames)
            {
                var iconDescription = iconType.GetField(iconName).GetCustomAttributes(false).OfType<IconDescriptionAttribute>().FirstOrDefault() ?? new IconDescriptionAttribute();
                if (string.IsNullOrWhiteSpace(iconDescription.IconCls))
                {
                    iconDescription.IconCls = "fa fa-" + iconName.ToLower();
                }
                if (string.IsNullOrWhiteSpace(iconDescription.Title))
                {
                    iconDescription.Title = iconName;
                }
                if (iconDescription.Handler == null)
                {
                    iconDescription.Handler = handlers.FirstOrDefault(x => x.Name == $"{iconName}Handler");
                }
                allIcons.Add(Enum.Parse<Icon>(iconName), iconDescription);
            }
        }

        internal protected void Handle(IconDescriptionAttribute iconDescription)
        {
            var handler = (IIconHandler)serviceProvider.GetService(iconDescription.Handler);
            if (handler == null)
            {
                Alert("该图标没有对应的处理程序");
                return;
            }
            handler.Handle(textarea);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Icons == null)
            {
                icons = allIcons;
            }
            else
            {
                icons = allIcons.Where(x => Icons.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value);
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (editorRendered)
            {
                return;
            }
            editorRendered = true;
            JSRuntime.InvokeVoidAsync("initilizeEditor", textarea, DotNetObjectReference.Create(this), Height, Value, EnableSyncScroll);
            RefreshPreview(Value);
        }

        [JSInvokable("scrollPreview")]
        public void ScrollPreview(float scrollTop)
        {
            JSRuntime.InvokeVoidAsync("scrollPreview", preview, scrollTop);
        }

        [JSInvokable("refreshPreview")]
        public void RefreshPreview(string value)
        {
            previewHtml = (MarkupString)Markdig.Markdown.ToHtml(value, pipeline);
            RequireRender = true;
            StateHasChanged();
        }
    }
}
