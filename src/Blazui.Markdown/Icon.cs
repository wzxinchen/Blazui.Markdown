using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazui.Markdown
{
    public enum Icon
    {
        /// <summary>
        /// 加粗
        /// </summary>
        [IconDescription(Title ="加粗")]
        Bold = 0,

        /// <summary>
        /// 删除线
        /// </summary>
        [IconDescription(Title = "删除线")]
        Strikethrough = 1,

        /// <summary>
        /// 斜体
        /// </summary>
        [IconDescription(Title = "斜体")]
        Italic = 2,

        /// <summary>
        /// 引用
        /// </summary>
        [IconDescription(Title = "引用", IconCls = "fa fa-quote-left")]
        BlockQuote = 3,

        /// <summary>
        /// 标题1
        /// </summary>
        [IconDescription(Text = "H1", Title = "一级标题", IconCls = "fa editormd-bold")]
        Heading1 = 4,

        /// <summary>
        /// 标题2
        /// </summary>
        [IconDescription(Text = "H2", Title = "二级标题", IconCls = "fa editormd-bold")]
        Heading2 = 5,

        /// <summary>
        /// 标题3
        /// </summary>
        [IconDescription(Text = "H3", Title = "三级标题", IconCls = "fa editormd-bold")]
        Heading3 = 6,

        /// <summary>
        /// 标题4
        /// </summary>
        [IconDescription(Text = "H4", Title = "四级标题", IconCls = "fa editormd-bold")]
        Heading4 = 7,

        /// <summary>
        /// 标题5
        /// </summary>
        [IconDescription(Text = "H5", Title = "五级标题", IconCls = "fa editormd-bold")]
        Heading5 = 8,

        /// <summary>
        /// 标题6
        /// </summary>
        [IconDescription(Text = "H6", Title = "六级标题", IconCls = "fa editormd-bold")]
        Heading6 = 9,

        /// <summary>
        /// 无序列表
        /// </summary>
        [IconDescription(Title = "无序列表", IconCls = "fa fa-list-ul")]
        UnorderedList = 10,

        /// <summary>
        /// 有序列表
        /// </summary>
        [IconDescription(Title = "有序列表", IconCls = "fa fa-list-ol")]
        OrderedList = 11,

        /// <summary>
        /// 水平线
        /// </summary>
        [IconDescription(Title = "水平线", IconCls = "fa fa-minus")]
        HorizontalRule = 12,

        /// <summary>
        /// 链接
        /// </summary>
        Link = 13,

        /// <summary>
        /// 图片
        /// </summary>
        [IconDescription(Title = "图片", IconCls = "fa fa-picture-o")]
        Image = 14,

        /// <summary>
        /// 行内代码
        /// </summary>
        [IconDescription(Title = "行内代码", IconCls = "fa fa-code")]
        CodeInline = 15,

        /// <summary>
        /// 代码块
        /// </summary>
        [IconDescription(Title = "代码块", IconCls = "fa fa-file-code-o")]
        CodeBlock = 16,

        /// <summary>
        /// 表格
        /// </summary>
        [IconDescription(Title = "表格", IconCls = "fa fa-table")]
        Tables = 17
    }
}
