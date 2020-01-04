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
        [IconDescription()]
        Bold = 0,

        /// <summary>
        /// 删除线
        /// </summary>
        Strikethrough = 1,

        /// <summary>
        /// 斜体
        /// </summary>
        Italic = 2,

        /// <summary>
        /// 引用
        /// </summary>
        BlockQuote = 3,

        /// <summary>
        /// 标题1
        /// </summary>
        Heading1 = 4,

        /// <summary>
        /// 标题2
        /// </summary>
        Heading2 = 5,

        /// <summary>
        /// 标题3
        /// </summary>
        Heading3 = 6,

        /// <summary>
        /// 标题4
        /// </summary>
        Heading4 = 7,

        /// <summary>
        /// 标题5
        /// </summary>
        Heading5 = 8,

        /// <summary>
        /// 标题6
        /// </summary>
        Heading6 = 9,

        /// <summary>
        /// 无序列表
        /// </summary>
        UnorderedList = 10,

        /// <summary>
        /// 有序列表
        /// </summary>
        OrderedList = 11,

        /// <summary>
        /// 水平线
        /// </summary>
        HorizontalRule = 12,

        /// <summary>
        /// 链接
        /// </summary>
        Link = 13,

        /// <summary>
        /// 图片
        /// </summary>
        Image = 14,

        /// <summary>
        /// 行内代码
        /// </summary>
        CodeInline = 15,

        /// <summary>
        /// 代码块
        /// </summary>
        CodeBlock = 16,

        /// <summary>
        /// 表格
        /// </summary>
        Tables = 17,

        /// <summary>
        /// 分隔线
        /// </summary>
        PageBreak
    }
}
