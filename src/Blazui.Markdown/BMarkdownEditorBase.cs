
using Blazui.Component;
using Blazui.Component.Dom;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazui.Markdown
{
    public class BMarkdownEditorBase : BComponentBase
    {
        internal static IDictionary<Icon, IconDescriptionAttribute> allIcons = new Dictionary<Icon, IconDescriptionAttribute>();

        internal IDictionary<Icon, IconDescriptionAttribute> icons;
        /// <summary>
        /// 工具栏图标
        /// </summary>
        public Icon[] Icons { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        [Parameter]
        public float Height { get; set; } = 300;
        internal ElementReference textarea;

        static BMarkdownEditorBase()
        {
            var iconType = typeof(Icon);
            var iconNames = Enum.GetNames(typeof(Icon));
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
                allIcons.Add(Enum.Parse<Icon>(iconName), iconDescription);
            }
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
            JSRuntime.InvokeVoidAsync("initilizeEditor", textarea);
        }
    }
}
